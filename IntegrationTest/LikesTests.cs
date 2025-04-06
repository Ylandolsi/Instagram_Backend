// using System.Net;
// using System.Net.Http.Json;
// using System.Security.Claims;
// using Instagram_Backend.Dtos;
// using Instagram_Backend.Models;
// using Microsoft.Extensions.DependencyInjection;
// using Xunit;

// namespace IntegrationTest;

// public class LikesTests
// {
//     private readonly InstagramWebApplicationFactory _factory;
//     private readonly HttpClient _client;
//     private readonly Guid _testUserId = Guid.NewGuid();
    
//     public LikesTests()
//     {
//         _factory = new InstagramWebApplicationFactory();
        
//         // Configure the test auth handler with our test user ID
//         _factory.WithWebHostBuilder(builder =>
//         {
//             builder.ConfigureServices(services =>
//             {
//                 services.Configure<TestAuthHandlerOptions>(options =>
//                 {
//                     options.Claims = new List<Claim>
//                     {
//                         new Claim(ClaimTypes.NameIdentifier, _testUserId.ToString()),
//                         new Claim(ClaimTypes.Name, "testuser@example.com")
//                     };
//                 });
//             });
//         });
        
//         _client = _factory.CreateClient();
//     }
    
//     [Fact]
//     public async Task ToggleLikePost_ReturnsOkResult()
//     {
//         // Arrange
//         var postId = await CreateTestPost();
        
//         // Act
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
//         var postId = await CreateTestPost();
//         var commentId = await CreateTestComment(postId);
        
//         // Act
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
//         var postId = await CreateTestPost();
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
//             UserId = _testUserId,
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
//             UserId = _testUserId,
//             Content = "Test comment",
//             CreatedAt = DateTime.UtcNow
//         };
        
//         db.Comments.Add(comment);
//         await db.SaveChangesAsync();
        
//         return comment.Id;
//     }
// }