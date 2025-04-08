using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;
using Instagram_Backend.Controllers;
using Instagram_Backend.Database;
using Instagram_Backend.Dtos;
using Instagram_Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace IntegrationTest;

public class UsersTests : IDisposable
{
    private readonly InstagramWebApplicationFactory _factory;
    private readonly HttpClient _client;
    private const string TestUserId = "ce95b43e-6587-480c-8ca6-9e217f0873fe";
    private const string OtherUserId = "a807c843-8b08-42a0-bec3-8e02ed7b4279";
    private readonly Guid _testUserIdGuid = Guid.Parse(TestUserId);
    private readonly Guid _otherUserIdGuid = Guid.Parse(OtherUserId);

    public UsersTests()
    {
        _factory = new InstagramWebApplicationFactory();
        _client = _factory.CreateClient();
    }

    public void Dispose()
    {
        _client?.Dispose();
        _factory?.Dispose();
    }

    private async Task<Guid> CreateTestUser(Guid IdCreate)
    {
        using var scope = _factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        
        // Check if user already exists
        if (await db.Users.AnyAsync(u => u.Id == IdCreate))
        {
            return IdCreate;
        }
        
        var user = new User
        {
            Id = IdCreate,
            UserName = $"testuser_{IdCreate.ToString().Substring(0, 8)}",
            Email = $"testuser_{IdCreate.ToString().Substring(0, 8)}@example.com",
            FirstName = "Test",
            LastName = "User",
            EmailConfirmed = true
        };
        
        db.Users.Add(user);
        await db.SaveChangesAsync();
        
        return IdCreate;
    }

    private async Task AddFollowerRelationship(Guid followerId, Guid targetUserId)
    {
        using var scope = _factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        
        var follower = await db.Users
            .Include(u => u.Following)
            .FirstOrDefaultAsync(u => u.Id == followerId);
            
        var target = await db.Users
            .FirstOrDefaultAsync(u => u.Id == targetUserId);
            
        if (follower == null || target == null)
            return;
            
        if (!follower.Following.Any(u => u.Id == targetUserId))
        {
            follower.Following.Add(target);
            await db.SaveChangesAsync();
        }
    }

    [Fact]
    public async Task GetFollowers_ReturnsFollowers()
    {
        // Arrange
        await CreateTestUser(_testUserIdGuid);
        await CreateTestUser(_otherUserIdGuid);
        await AddFollowerRelationship(_otherUserIdGuid, _testUserIdGuid);
        
        // Act
        _client.DefaultRequestHeaders.Clear(); 
        await _factory.AuthenticateClient(_client, _testUserIdGuid.ToString());
        var response = await _client.GetAsync($"/api/users/{_testUserIdGuid}/followers");
        
        // Assert
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<ApiResponse<PagedResult<UserDto>>>();
        Assert.NotNull(result);
        Assert.NotNull(result.Data);
        Assert.True(result.Data.Items.Count > 0);
        Assert.Contains(result.Data.Items, user => user.Id == _otherUserIdGuid);
        
        _client.DefaultRequestHeaders.Clear();
    }

    [Fact]
    public async Task GetFollowing_ReturnsFollowing()
    {
        // Arrange
        await CreateTestUser(_testUserIdGuid);
        await CreateTestUser(_otherUserIdGuid);
        await AddFollowerRelationship(_testUserIdGuid, _otherUserIdGuid);
        
        // Act
        _client.DefaultRequestHeaders.Clear(); 
        await _factory.AuthenticateClient(_client, _testUserIdGuid.ToString());
        var response = await _client.GetAsync($"/api/users/{_testUserIdGuid}/following");
        
        // Assert
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<ApiResponse<PagedResult<UserDto>>>();
        Assert.NotNull(result);
        Assert.NotNull(result.Data);
        Assert.True(result.Data.Items.Count > 0);
        Assert.Contains(result.Data.Items, user => user.Id == _otherUserIdGuid);
        
        _client.DefaultRequestHeaders.Clear();
    }

    [Fact]
    public async Task FollowUser_Success()
    {
        // Arrange
        await CreateTestUser(_testUserIdGuid);
        await CreateTestUser(_otherUserIdGuid);
        
        // Act
        _client.DefaultRequestHeaders.Clear(); 
        await _factory.AuthenticateClient(_client, _testUserIdGuid.ToString());
        var response = await _client.PostAsync($"/api/users/{_otherUserIdGuid}/follow", null);
        
        // Assert
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<ApiResponse<object>>();
        Assert.NotNull(result);
        
        // Verify in database
        using var scope = _factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var user = await db.Users
            .Include(u => u.Following)
            .FirstAsync(u => u.Id == _testUserIdGuid);
        Assert.Contains(user.Following, f => f.Id == _otherUserIdGuid);
        
        _client.DefaultRequestHeaders.Clear();
    }

    [Fact]
    public async Task FollowUser_Unauthorized_ReturnsUnauthorized()
    {
        // Arrange
        await CreateTestUser(_testUserIdGuid);
        await CreateTestUser(_otherUserIdGuid);
        // No authentication
        _client.DefaultRequestHeaders.Clear(); 
        await _factory.AuthenticateClient(_client , "anonymous") ; 
        // Act
        var response = await _client.PostAsync($"/api/users/{_otherUserIdGuid}/follow", null);
        
        // Assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        
        _client.DefaultRequestHeaders.Clear();
    }

    [Fact]
    public async Task FollowSelf_ReturnsBadRequest()
    {
        // Arrange
        await CreateTestUser(_testUserIdGuid);

        _client.DefaultRequestHeaders.Clear(); 
        await _factory.AuthenticateClient(_client, _testUserIdGuid.ToString());
        // Act
        var response = await _client.PostAsync($"/api/users/{_testUserIdGuid}/follow", null);
        
        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        
        _client.DefaultRequestHeaders.Clear();
    }

    [Fact]
    public async Task FollowNonExistentUser_ReturnsNotFound()
    {
        // Arrange
        await CreateTestUser(_testUserIdGuid);
        var nonExistentUserId = Guid.NewGuid();

        _client.DefaultRequestHeaders.Clear(); 
        await _factory.AuthenticateClient(_client, _testUserIdGuid.ToString());
        
        // Act
        var response = await _client.PostAsync($"/api/users/{nonExistentUserId}/follow", null);
        
        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        
        _client.DefaultRequestHeaders.Clear();
    }

    [Fact]
    public async Task UnfollowUser_Success()
    {
        // Arrange
        await CreateTestUser(_testUserIdGuid);
        await CreateTestUser(_otherUserIdGuid);
        await AddFollowerRelationship(_testUserIdGuid, _otherUserIdGuid);


        _client.DefaultRequestHeaders.Clear(); 
        await _factory.AuthenticateClient(_client, _testUserIdGuid.ToString());
        
        // Act
        var response = await _client.PostAsync($"/api/users/{_otherUserIdGuid}/unfollow", null);
        
        // Assert
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<ApiResponse<object>>();
        Assert.NotNull(result);
        
        // Verify in database
        using var scope = _factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var user = await db.Users
            .Include(u => u.Following)
            .FirstAsync(u => u.Id == _testUserIdGuid);
        Assert.DoesNotContain(user.Following, f => f.Id == _otherUserIdGuid);
        
        _client.DefaultRequestHeaders.Clear();
    }

    [Fact]
    public async Task UnfollowUser_Unauthorized_ReturnsUnauthorized()
    {
        // Arrange
        await CreateTestUser(_testUserIdGuid);
        await CreateTestUser(_otherUserIdGuid);
        await AddFollowerRelationship(_testUserIdGuid, _otherUserIdGuid);
        // No authentication
        _client.DefaultRequestHeaders.Clear(); 
        await _factory.AuthenticateClient(_client , "anonymous") ; 
        // Act
        var response = await _client.PostAsync($"/api/users/{_otherUserIdGuid}/unfollow", null);
        
        // Assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        
        _client.DefaultRequestHeaders.Clear();
    }

    [Fact]
    public async Task UnfollowSelf_ReturnsBadRequest()
    {
        // Arrange
        await CreateTestUser(_testUserIdGuid);
        
        _client.DefaultRequestHeaders.Clear(); 
        await _factory.AuthenticateClient(_client, _testUserIdGuid.ToString());
        // Act
        var response = await _client.PostAsync($"/api/users/{_testUserIdGuid}/unfollow", null);
        
        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        
        _client.DefaultRequestHeaders.Clear();
    }

    [Fact]
    public async Task UnfollowNonExistentUser_ReturnsNotFound()
    {
        // Arrange
        await CreateTestUser(_testUserIdGuid);
        var nonExistentUserId = Guid.NewGuid();
        
        _client.DefaultRequestHeaders.Clear(); 
        await _factory.AuthenticateClient(_client, _testUserIdGuid.ToString());
        // Act
        var response = await _client.PostAsync($"/api/users/{nonExistentUserId}/unfollow", null);
        
        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        
        _client.DefaultRequestHeaders.Clear();
    }

    [Fact]
    public async Task UnfollowUserNotCurrentlyFollowing_ReturnsBadRequest()
    {
        // Arrange
        await CreateTestUser(_testUserIdGuid);
        await CreateTestUser(_otherUserIdGuid);
        // Not adding follow relationship
        _client.DefaultRequestHeaders.Clear(); 
        await _factory.AuthenticateClient(_client, _testUserIdGuid.ToString());
        
        // Act
        var response = await _client.PostAsync($"/api/users/{_otherUserIdGuid}/unfollow", null);
        
        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        
        _client.DefaultRequestHeaders.Clear();
    }

    [Fact]
    public async Task GetFollowers_EmptyFollowers_ReturnsEmptyList()
    {
        // Arrange
        await CreateTestUser(_testUserIdGuid);
        // No followers added
        _client.DefaultRequestHeaders.Clear(); 
        await _factory.AuthenticateClient(_client, _testUserIdGuid.ToString());
        // Act
        var response = await _client.GetAsync($"/api/users/{_testUserIdGuid}/followers");
        
        // Assert
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<ApiResponse<PagedResult<UserDto>>>();
        Assert.NotNull(result);
        Assert.NotNull(result.Data);
        Assert.Empty(result.Data.Items);
        
        _client.DefaultRequestHeaders.Clear();
    }

    [Fact]
    public async Task GetFollowing_EmptyFollowing_ReturnsEmptyList()
    {
        // Arrange
        await CreateTestUser(_testUserIdGuid);
        // No following added
        _client.DefaultRequestHeaders.Clear(); 
        await _factory.AuthenticateClient(_client, _testUserIdGuid.ToString());
        // Act
        var response = await _client.GetAsync($"/api/users/{_testUserIdGuid}/following");
        
        // Assert
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<ApiResponse<PagedResult<UserDto>>>();
        Assert.NotNull(result);
        Assert.NotNull(result.Data);
        Assert.Empty(result.Data.Items);
        
        _client.DefaultRequestHeaders.Clear();
    }
    [Fact]
    public async Task SearchUsers_ReturnsMatchingUsers()
    {
        // Arrange
        // Create users with distinctive searchable names
        await CreateTestUser(_otherUserIdGuid, "Jane", "Smith", "janesmith456");

        // Create additional test users with different name patterns
        var userId3 = Guid.NewGuid();
        await CreateTestUser(userId3, "John", "Johnson", "johnny789");
        
        var userId4 = Guid.NewGuid();
        await CreateTestUser(userId4, "Janet", "Williams", "jwilliams");
        
        var userId5 = Guid.NewGuid();
        await CreateTestUser(userId5, "Robert", "Smith", "robsmith");

        var userId6 = Guid.NewGuid();
        await CreateTestUser(userId6, "Johnnn", "Doenn", "johndoe123");
        
        _client.DefaultRequestHeaders.Clear(); 
        await _factory.AuthenticateClient(_client, _testUserIdGuid.ToString());
        

        // Act - Search for "john" (should match John Doe and John Johnson)
        var response = await _client.GetAsync("/api/users/search?query=joh&page=1&pageSize=10");
        
        // Assert
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<ApiResponse<PagedResult<UserDto>>>();
        
        foreach (var user in result.Data.Items)
        {
            Console.WriteLine($"User: {user.UserName}");
        }

        Assert.NotNull(result);
        Assert.NotNull(result.Data);
        Assert.Equal(2, result.Data.Items.Count);
        Assert.Contains(result.Data.Items, user => user.UserName == "johndoe123");
        Assert.Contains(result.Data.Items, user => user.UserName == "johnny789");
        Assert.DoesNotContain(result.Data.Items, user => user.UserName == "janesmith456");
        
        // Act - Search for "smith" (should match Jane Smith and Robert Smith)
        response = await _client.GetAsync("/api/users/search?query=smith&page=1&pageSize=10");
        
        // Assert
        response.EnsureSuccessStatusCode();
        result = await response.Content.ReadFromJsonAsync<ApiResponse<PagedResult<UserDto>>>();
        
        Assert.NotNull(result);
        Assert.NotNull(result.Data);
        Assert.Equal(2, result.Data.Items.Count);
        Assert.Contains(result.Data.Items, user => user.UserName == "janesmith456");
        Assert.Contains(result.Data.Items, user => user.UserName == "robsmith");
        
        _client.DefaultRequestHeaders.Clear();
    }
    [Fact]
    public async Task SearchUsers_WithShortQuery_ReturnsBadRequest()
    {
        // Arrange
        await CreateTestUser(_testUserIdGuid);
        
        _client.DefaultRequestHeaders.Clear(); 
        await _factory.AuthenticateClient(_client, _testUserIdGuid.ToString());
        
        // Act - Search with a single character
        var response = await _client.GetAsync("/api/users/search?query=j&page=1&pageSize=10");
        
        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        
        _client.DefaultRequestHeaders.Clear();
    }

    [Fact]
    public async Task SearchUsers_WithNoResults_ReturnsEmptyList()
    {
        // Arrange
        await CreateTestUser(_testUserIdGuid);
        
        _client.DefaultRequestHeaders.Clear(); 
        await _factory.AuthenticateClient(_client, _testUserIdGuid.ToString());
        
        // Act - Search for something that shouldn't match any users
        var response = await _client.GetAsync("/api/users/search?query=xyz123&page=1&pageSize=10");
        
        // Assert
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<ApiResponse<PagedResult<UserDto>>>();
        
        Assert.NotNull(result);
        Assert.NotNull(result.Data);
        Assert.Empty(result.Data.Items);
        
        _client.DefaultRequestHeaders.Clear();
    }

    private async Task<Guid> CreateTestUser(Guid IdCreate, string firstName, string lastName, string userName)
    {
        using var scope = _factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        
        // Check if user already exists
        if (await db.Users.AnyAsync(u => u.Id == IdCreate))
        {
            if ( IdCreate == _testUserIdGuid)
            {
                Console.WriteLine($"User already created : {IdCreate}");
            }

            // Update the existing user with the provided name properties
            var existingUser = await db.Users.FindAsync(IdCreate);
            if (existingUser != null)
            {
                existingUser.FirstName = firstName;
                existingUser.LastName = lastName;
                existingUser.UserName = userName;
                await db.SaveChangesAsync();
            }
            return IdCreate;
        }
        
        var user = new User
        {
            Id = IdCreate,
            UserName = userName,
            Email = $"{userName}@example.com",
            FirstName = firstName,
            LastName = lastName,
            EmailConfirmed = true
        };
        
        db.Users.Add(user);
        await db.SaveChangesAsync();
            if ( IdCreate == _testUserIdGuid)
        {
                Console.WriteLine($"User newly created : {IdCreate}");
            }
        return IdCreate;
    }
}