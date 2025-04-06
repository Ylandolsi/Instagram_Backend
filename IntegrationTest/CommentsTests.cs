// using System.Net;
// using System.Net.Http.Json;
// using System.Security.Claims;
// using System.Text;
// using System.Text.Json;
// using Instagram_Backend.Dtos;
// using Instagram_Backend.Dtos.Comments;
// using Instagram_Backend.Models;
// using Microsoft.AspNetCore.Authentication;
// using Microsoft.Extensions.DependencyInjection;
// using Xunit;

// namespace IntegrationTest;

// public class CommentsTests
// {
//     private readonly InstagramWebApplicationFactory _factory;
//     private readonly HttpClient _client;
//     private readonly Guid _testUserId = Guid.NewGuid();
    
//     public CommentsTests()
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
//     public async Task CreateComment_WithValidData_ReturnsOkResult()
//     {
//         // Arrange
//         var postId = await CreateTestPost();
//         var commentDto = new CreateCommentDto { Content = "Test comment" };
//         var content = new StringContent(JsonSerializer.Serialize(commentDto), Encoding.UTF8, "application/json");
        
//         // Act
//         var response = await _client.PostAsync($"/api/comments/{postId}", content);
        
//         // Assert
//         response.EnsureSuccessStatusCode();
//         var result = await response.Content.ReadFromJsonAsync<ApiResponse<bool>>();
//         Assert.NotNull(result);
//         Assert.True(result.Data);
//     }
    
//     [Fact]
//     public async Task GetPostComments_ReturnsOkResult()
//     {
//         // Arrange
//         var postId = await CreateTestPost();
//         await CreateTestComment(postId);
        
//         // Act
//         var response = await _client.GetAsync($"/api/comments/posts/{postId}?page=1&pageSize=10");
        
//         // Assert
//         response.EnsureSuccessStatusCode();
//         var result = await response.Content.ReadFromJsonAsync<ApiResponse<PagedResult<CommentDto>>>();
//         Assert.NotNull(result);
//     }
    
//     [Fact]
//     public async Task UpdateComment_WithValidData_ReturnsOkResult()
//     {
//         // Arrange
//         var postId = await CreateTestPost();
//         var commentId = await CreateTestComment(postId);
//         var updateDto = new UpdateCommentDto { Content = "Updated comment" };
//         var content = new StringContent(JsonSerializer.Serialize(updateDto), Encoding.UTF8, "application/json");
        
//         // Act
//         var response = await _client.PutAsync($"/api/comments/{commentId}", content);
        
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