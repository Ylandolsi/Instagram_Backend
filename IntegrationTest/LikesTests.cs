// using System.Net;
// using System.Net.Http.Json;
// using System.Security.Claims;
// using Instagram_Backend.Controllers;
// using Instagram_Backend.Database;
// using Instagram_Backend.Dtos;
// using Instagram_Backend.Models;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.DependencyInjection;
// using Xunit;

// namespace IntegrationTest;

// public class LikesTests
// {
//     private readonly InstagramWebApplicationFactory _factory;
//     private readonly HttpClient _client;
//     private const string TestUserId = "ce95b43e-6587-480c-8ca6-9e217f0873fe";

//     private const string OtherUserId = "a807c843-8b08-42a0-bec3-8e02ed7b4279";
//     private readonly Guid _testUserIdGuid = Guid.Parse(TestUserId);
//     private readonly Guid _otherUserIdGuid = Guid.Parse(OtherUserId);
    
//     public LikesTests()
//     {
//         _factory = new InstagramWebApplicationFactory();
//         _client = _factory.CreateClient();
//     }


//     [Fact]
//     public async Task ToggleLikePost_ReturnsOkResult()
//     {
//         // Arrange
//         await CreateTestUser(); 
//         var postId = await CreateTestPost();
        
//         // Act
//         _client.DefaultRequestHeaders.Clear(); 
//         await _factory.AuthenticateClient(_client, _testUserIdGuid.ToString());
//         var response = await _client.PostAsync($"/api/likes/posts/{postId}/toggle", null);
        
//         // Assert
//         response.EnsureSuccessStatusCode();
//         var result = await response.Content.ReadFromJsonAsync<ApiResponse<bool>>();
//         Assert.NotNull(result);
//         Assert.True(result.Data);
//     }
    
//     [Fact]
//     public async Task ToggleLikeComment_ReturnsOkResult()
//     {
//         // Arrange
//         await CreateTestUser(); 
//         var postId = await CreateTestPost();
//         var commentId = await CreateTestComment(postId);
        
//         // Act
//         _client.DefaultRequestHeaders.Clear(); 
//         await _factory.AuthenticateClient(_client, _testUserIdGuid.ToString());
//         var response = await _client.PostAsync($"/api/likes/comments/{commentId}/toggle", null);
        
//         // Assert
//         response.EnsureSuccessStatusCode();
//         var result = await response.Content.ReadFromJsonAsync<ApiResponse<bool>>();
//         Assert.NotNull(result);
//     }
    
//     [Fact]
//     public async Task IsPostLikedByUser_ReturnsOkResult()
//     {
//         // Arrange
//         await CreateTestUser(); 
//         var postId = await CreateTestPost();

//         _client.DefaultRequestHeaders.Clear(); 
//         await _factory.AuthenticateClient(_client, _testUserIdGuid.ToString());
        
//         await _client.PostAsync($"/api/likes/posts/{postId}/toggle", null);
        
//         // Act
//         var response = await _client.GetAsync($"/api/likes/posts/{postId}/isliked");
        
//         // Assert
//         response.EnsureSuccessStatusCode();
//         var result = await response.Content.ReadFromJsonAsync<ApiResponse<bool>>();
//         Assert.NotNull(result);
//         Assert.True(result.Data);
//     }
    
//     private async Task<Guid> CreateTestPost()
//     {
//         using var scope = _factory.Services.CreateScope();
//         var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        
//         var post = new Post
//         {
//             Id = Guid.NewGuid(),
//             UserId = _testUserIdGuid,
//             Caption = "Test post",
//             CreatedAt = DateTime.UtcNow
//         };
        
//         db.Posts.Add(post);
//         await db.SaveChangesAsync();
        
//         return post.Id;
//     }
    
//     private async Task<Guid> CreateTestComment(Guid postId)
//     {
//         using var scope = _factory.Services.CreateScope();
//         var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        
//         var comment = new Comment
//         {
//             Id = Guid.NewGuid(),
//             PostId = postId,
//             UserId = _testUserIdGuid,
//             Content = "Test comment",
//             CreatedAt = DateTime.UtcNow
//         };
        
//         db.Comments.Add(comment);
//         await db.SaveChangesAsync();
        
//         return comment.Id;
//     }
//     private async Task<Guid> CreateTestUser()
//     {
//         using var scope = _factory.Services.CreateScope();
//         var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        
//         // Check if user already exists
//         if (await db.Users.AnyAsync(u => u.Id == _testUserIdGuid))
//         {
//             return _testUserIdGuid;
//         }
        
//         var user = new User
//         {
//             Id = _testUserIdGuid,
//             UserName = "testuser",
//             Email = "testuser@example.com",
//             FirstName = "Test",
//             LastName = "User",
//             EmailConfirmed = true
//         };
        
//         db.Users.Add(user);
//         await db.SaveChangesAsync();
        
//         return _testUserIdGuid;
//     }
    
// }