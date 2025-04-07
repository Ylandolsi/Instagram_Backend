using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Instagram_Backend.Controllers;
using Instagram_Backend.Database;
using Instagram_Backend.Dtos;
using Instagram_Backend.Dtos.Posts;
using Instagram_Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTest;

public class PostsTests 
{
    private const string TestUserId = "ce95b43e-6587-480c-8ca6-9e217f0873fe";

    private const string OtherUserId = "a807c843-8b08-42a0-bec3-8e02ed7b4279";
    private readonly Guid _testUserIdGuid = Guid.Parse(TestUserId);
    private readonly Guid _otherUserIdGuid = Guid.Parse(OtherUserId);
    
    private readonly InstagramWebApplicationFactory _factory;
    private readonly HttpClient _client;
    
    public PostsTests()
    {
        _factory = new InstagramWebApplicationFactory();
        _client = _factory.CreateClient();
    }


    #region GET Single Post
    
    [Fact]
    public async Task GetPost_WithValidId_ReturnsOkResult()
    {
        
        // Arrange
        await CreateTestUser();
        var postId = await CreateTestPostWithImages();
        
        // Act
        var response = await _client.GetAsync($"/api/posts/{postId}");
        
        // Assert
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<ApiResponse<PostDto>>();
        Assert.NotNull(result);
        Assert.NotNull(result.Data);
        Assert.Equal(postId, result.Data.Id);
        Assert.Equal("Test post", result.Data.Caption);
        Assert.NotEmpty(result.Data.Images);
    }
    
    [Fact]
    public async Task GetPost_WithInvalidId_ReturnsBadRequest()
    {
        // Arrange
        await CreateTestUser();
        
        // Act
        var response = await _client.GetAsync($"/api/posts/{Guid.Empty}");
        
        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

    }
    
    [Fact]
    public async Task GetPost_WithNonExistentId_ReturnsNotFound()
    {
        // Arrange
        await CreateTestUser();
        var nonExistentId = Guid.NewGuid();
        
        _client.DefaultRequestHeaders.Clear(); 
        await _factory.AuthenticateClient(_client, TestUserId);
        // Act
        var response = await _client.GetAsync($"/api/posts/{nonExistentId}");
        
        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    
    #endregion
    
    #region GET User Posts
    
    [Fact]
    public async Task GetUserPosts_ReturnsOkResult()
    {
        // Arrange
        await CreateTestUser();
        await CreateTestPost(); // Create a post without images
        await CreateTestPostWithImages(); // Create a post with images
        
        // Act
        var response = await _client.GetAsync($"/api/posts/user/{_testUserIdGuid}?page=1&pageSize=10");
        
        // Assert
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<ApiResponse<PagedResult<PostDto>>>();
        
        Assert.NotNull(result);
        Assert.NotNull(result.Data);
        Assert.Equal(2, result.Data.Items.Count);
        Assert.Equal(2, result.Data.TotalCount);
        Assert.Equal(1, result.Data.Page);
        Assert.Equal(10, result.Data.PageSize);
    }
    
    [Fact]
    public async Task GetUserPosts_WithPagination_ReturnsCorrectPage()
    {
        // Arrange
        await CreateTestUser();
        
        // Create 5 test posts
        for (int i = 0; i < 5; i++)
        {
            await CreateTestPost($"Test post {i}");
        }
        
        // Act - get page 1 with pageSize 2
        var response = await _client.GetAsync($"/api/posts/user/{_testUserIdGuid}?page=1&pageSize=2");
        
        // Assert
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<ApiResponse<PagedResult<PostDto>>>();
        
        Assert.NotNull(result);
        Assert.NotNull(result.Data);
        Assert.Equal(2, result.Data.Items.Count);
        Assert.Equal(5, result.Data.TotalCount);
        Assert.Equal(1, result.Data.Page);
        Assert.Equal(2, result.Data.PageSize);
        
        // Act - get page 2 with pageSize 2
        response = await _client.GetAsync($"/api/posts/user/{_testUserIdGuid}?page=2&pageSize=2");
        
        // Assert
        response.EnsureSuccessStatusCode();
        result = await response.Content.ReadFromJsonAsync<ApiResponse<PagedResult<PostDto>>>();
        
        Assert.NotNull(result);
        Assert.NotNull(result.Data);
        Assert.Equal(2, result.Data.Items.Count);
        Assert.Equal(5, result.Data.TotalCount);
        Assert.Equal(2, result.Data.Page);
    }
    
    [Fact]
    public async Task GetUserPosts_WithInvalidUserId_ReturnsBadRequest()
    {
        // Arrange
        await CreateTestUser();
        
        // Act
        var response = await _client.GetAsync($"/api/posts/user/{Guid.Empty}?page=1&pageSize=10");
        
        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    
    #endregion
    
    #region GET All Posts (Feed)
    
    [Fact]
    public async Task GetAllPosts_ReturnsOkResult()
    {
        // Arrange
        await CreateTestUser();
        await CreateOtherUser();
        
        // Create posts for both users
        await CreateTestPost("Test post from test user");
        await CreatePostForUser(_otherUserIdGuid, "Test post from other user");
        
        // Act
        var response = await _client.GetAsync("/api/posts?page=1&pageSize=10");
        
        // Assert
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<ApiResponse<PagedResult<PostDto>>>();
        
        Assert.NotNull(result);
        Assert.NotNull(result.Data);
        Assert.Equal(2, result.Data.Items.Count);
        Assert.Equal(2, result.Data.TotalCount);
    }
    
    #endregion
    
    #region POST Create Post
    
    [Fact]
    public async Task CreatePost_WithValidData_ReturnsOkResult()
    {
        // Arrange
        await CreateTestUser();
        
        var formData = new MultipartFormDataContent();
        formData.Add(new StringContent("Test post creation"), "Caption");
        
        // Add a test file
        var fileName = "test-image.jpg";
        var fileContent = new ByteArrayContent(new byte[100]);
        fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
        formData.Add(fileContent, "file", fileName);
        
        // Act
        var response = await _client.PostAsync("/api/posts", formData);
        
        // Assert
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<ApiResponse<bool>>();
        Assert.NotNull(result);
        Assert.True(result.Data);
    }
    
    [Fact]
    public async Task CreatePost_WithMultipleFiles_ReturnsOkResult()
    {
        // Arrange
        await CreateTestUser();
        
        var formData = new MultipartFormDataContent();
        formData.Add(new StringContent("Post with multiple images"), "Caption");
        
        // Add multiple test files
        for (int i = 0; i < 3; i++)
        {
            var fileName = $"test-image-{i}.jpg";
            var fileContent = new ByteArrayContent(new byte[100]);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            formData.Add(fileContent, "file", fileName);
        }
        
        // Act
        var response = await _client.PostAsync("/api/posts", formData);
        
        // Assert
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<ApiResponse<bool>>();
        Assert.NotNull(result);
        Assert.True(result.Data);
    }
    
    [Fact]
    public async Task CreatePost_WithNoFiles_ReturnsBadRequest()
    {
        // Arrange
        await CreateTestUser();
        
        var formData = new MultipartFormDataContent();
        formData.Add(new StringContent("Post with no images"), "Caption");
        
        // Act
        var response = await _client.PostAsync("/api/posts", formData);
        
        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    
    #endregion
    
    #region PUT Update Post
    
    [Fact]
    public async Task UpdatePost_WithValidData_ReturnsOkResult()
    {
        // Arrange
        await CreateTestUser();
        var postId = await CreateTestPost();
        
        var body = new UpdatePostDto
        {
            Caption = "Updated caption"
        };
        var json = JsonSerializer.Serialize(body);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        
        // Act
        var response = await _client.PutAsync($"/api/posts/{postId}", content);
        
        // Assert
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<ApiResponse<bool>>();
        Assert.NotNull(result);
        Assert.True(result.Data);
        
        // Verify the update
        var getResponse = await _client.GetAsync($"/api/posts/{postId}");
        getResponse.EnsureSuccessStatusCode();
        var getResult = await getResponse.Content.ReadFromJsonAsync<ApiResponse<PostDto>>();
        Assert.Equal("Updated caption", getResult.Data.Caption);
    }
    
    [Fact]
    public async Task UpdatePost_WithInvalidId_ReturnsBadRequest()
    {
        // Arrange
        await CreateTestUser();
        
        var body = new UpdatePostDto
        {
            Caption = "Updated caption"
        };
        var json = JsonSerializer.Serialize(body);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        
        // Act
        var response = await _client.PutAsync($"/api/posts/{Guid.Empty}", content);
        
        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    
    [Fact]
    public async Task UpdatePost_NonExistentPost_ReturnsNotFound()
    {
        // Arrange
        await CreateTestUser();
        var nonExistentId = Guid.NewGuid();
        
        var body = new UpdatePostDto
        {
            Caption = "Updated caption"
        };
        var json = JsonSerializer.Serialize(body);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        
        // Act
        var response = await _client.PutAsync($"/api/posts/{nonExistentId}", content);
        
        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    
    [Fact]
    public async Task UpdatePost_PostBelongingToAnotherUser_ReturnsNotFound()
    {
        await _factory.AuthenticateClient(_client, TestUserId);
        // Arrange
        await CreateTestUser();
        await CreateOtherUser();
        
        // Create a post owned by the other user
        var otherUserPostId = await CreatePostForUser(_otherUserIdGuid);
        
        var body = new UpdatePostDto
        {
            Caption = "Updated caption"
        };
        var json = JsonSerializer.Serialize(body);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        
        // Act
        var response = await _client.PutAsync($"/api/posts/{otherUserPostId}", content);
        
        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        _client.DefaultRequestHeaders.Clear();
    }
    
    #endregion
    
    #region DELETE Post
    
    [Fact]
    public async Task DeletePost_WithValidData_ReturnsOkResult()
    {
        // Arrange
        await CreateTestUser();
        var postId = await CreateTestPost();
        
        // Act
        var response = await _client.DeleteAsync($"/api/posts/{postId}");
        
        // Assert
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<ApiResponse<bool>>();
        Assert.NotNull(result);
        Assert.True(result.Data);
        
        // Verify the post is deleted
        var getResponse = await _client.GetAsync($"/api/posts/{postId}");
        Assert.Equal(HttpStatusCode.NotFound, getResponse.StatusCode);
    }
    
    [Fact]
    public async Task DeletePost_WithInvalidId_ReturnsBadRequest()
    {
        // Arrange
        await CreateTestUser();
        
        // Act
        var response = await _client.DeleteAsync($"/api/posts/{Guid.Empty}");
        
        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    
    [Fact]
    public async Task DeletePost_NonExistentPost_ReturnsNotFound()
    {
        // Arrange
        await CreateTestUser();
        var nonExistentId = Guid.NewGuid();
        
        // Act
        var response = await _client.DeleteAsync($"/api/posts/{nonExistentId}");
        
        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    
    [Fact]
    public async Task DeletePost_PostBelongingToAnotherUser_ReturnsNotFound()
    {
        _client.DefaultRequestHeaders.Clear(); 

        // Arrange
        await CreateTestUser();
        await CreateOtherUser();
        
        // Create a post owned by the other user
        var otherUserPostId = await CreatePostForUser(_otherUserIdGuid);
        
        await _factory.AuthenticateClient(_client, TestUserId);
        // Act
        var response = await _client.DeleteAsync($"/api/posts/{otherUserPostId}");
        
        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    
    #endregion
    
    #region Helper Methods
    
    private async Task<Guid> CreateTestUser()
    {
        using var scope = _factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        
        // Check if user already exists
        if (await db.Users.AnyAsync(u => u.Id == _testUserIdGuid))
        {
            return _testUserIdGuid;
        }
        
        var user = new User
        {
            Id = _testUserIdGuid,
            UserName = "testuser",
            Email = "testuser@example.com",
            FirstName = "Test",
            LastName = "User",
            EmailConfirmed = true
        };
        
        db.Users.Add(user);
        await db.SaveChangesAsync();
        
        return _testUserIdGuid;
    }
    
    private async Task<Guid> CreateOtherUser()
    {
        using var scope = _factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        
        // Check if user already exists
        if (await db.Users.AnyAsync(u => u.Id == _otherUserIdGuid))
        {
            return _otherUserIdGuid;
        }
        
        var user = new User
        {
            Id = _otherUserIdGuid,
            UserName = "otheruser",
            Email = "otheruser@example.com",
            FirstName = "Other",
            LastName = "User",
            EmailConfirmed = true
        };
        
        db.Users.Add(user);
        await db.SaveChangesAsync();
        
        return _otherUserIdGuid;
    }
    
    private async Task<Guid> CreateTestPost(string caption = "Test post")
    {
        using var scope = _factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        
        var postId = Guid.NewGuid();
        var post = new Post
        {
            Id = postId,
            UserId = _testUserIdGuid,
            Caption = caption,
            CreatedAt = DateTime.UtcNow
        };
        
        db.Posts.Add(post);
        await db.SaveChangesAsync();
        
        return postId;
    }
    
    private async Task<Guid> CreatePostForUser(Guid userId, string caption = "Test post")
    {
        using var scope = _factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        
        var postId = Guid.NewGuid();
        var post = new Post
        {
            Id = postId,
            UserId = userId,
            Caption = caption,
            CreatedAt = DateTime.UtcNow
        };
        
        db.Posts.Add(post);
        await db.SaveChangesAsync();
        
        return postId;
    }
    
    private async Task<Guid> CreateTestPostWithImages(string caption = "Test post")
    {
        using var scope = _factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        
        var postId = Guid.NewGuid();
        var post = new Post
        {
            Id = postId,
            UserId = _testUserIdGuid,
            Caption = caption,
            CreatedAt = DateTime.UtcNow,
            Images = new List<Image>
            {
                new Image
                {
                    Id = Guid.NewGuid(),
                    PostId = postId,
                    Url = "https://testurl.com/image1.jpg",
                    Order = 0
                },
                new Image
                {
                    Id = Guid.NewGuid(),
                    PostId = postId,
                    Url = "https://testurl.com/image2.jpg",
                    Order = 1
                }
            }
        };
        
        db.Posts.Add(post);
        await db.SaveChangesAsync();
        
        return postId;
    }
    
    #endregion
}


