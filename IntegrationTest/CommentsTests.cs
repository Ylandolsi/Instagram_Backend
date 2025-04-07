// using System.Net;
// using System.Net.Http.Json;
// using System.Text;
// using System.Text.Json;
// using Instagram_Backend.Controllers;
// using Instagram_Backend.Database;
// using Instagram_Backend.Dtos;
// using Instagram_Backend.Dtos.Comments;
// using Instagram_Backend.Models;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.DependencyInjection;
// using Xunit;

// namespace IntegrationTest;

// public class CommentsTests : IDisposable
// {
//     private const string TestUserId = "ce95b43e-6587-480c-8ca6-9e217f0873fe";
//     private readonly Guid _testUserIdGuid = Guid.Parse(TestUserId);
//     private readonly Guid _otherUserIdGuid = Guid.NewGuid();
    
//     private readonly InstagramWebApplicationFactory _factory;
//     private readonly HttpClient _client;
    
//     public CommentsTests()
//     {
//         _factory = new InstagramWebApplicationFactory();
        
//         _client = _factory.CreateClient();
//     }
    
//     public void Dispose()
//     {
//         _factory?.Dispose();
//         _client?.Dispose();
//     }

//     private async Task<Guid> SetupTestPostAsync()
//     {
//         // Use a scope to access the database
//         using var scope = _factory.Services.CreateScope();
//         var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        
//         // Create a test post
//         var post = new Post
//         {
//             Id = Guid.NewGuid(),
//             UserId = _testUserIdGuid,
//             Caption = "Test post for comments",
//             CreatedAt = DateTime.UtcNow
//         };
        
//         dbContext.Posts.Add(post);
//         await dbContext.SaveChangesAsync();
        
//         return post.Id;
//     }
    
//     private async Task<Guid> CreateTestCommentAsync(Guid postId, Guid? parentCommentId = null)
//     {
//         using var scope = _factory.Services.CreateScope();
//         var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        
//         var comment = new Comment
//         {
//             Id = Guid.NewGuid(),
//             UserId = _testUserIdGuid,
//             PostId = postId,
//             Content = "Test comment content",
//             CreatedAt = DateTime.UtcNow,
//             ParentCommentId = parentCommentId
//         };
        
//         dbContext.Comments.Add(comment);
        
//         // Update parent comment reply count if this is a reply
//         if (parentCommentId.HasValue)
//         {
//             var parentComment = await dbContext.Comments.FindAsync(parentCommentId.Value);
//             if (parentComment != null)
//             {
//                 parentComment.ReplyCount += 1;
//                 dbContext.Comments.Update(parentComment);
//             }
//         }
        
//         // Update post comment count
//         var post = await dbContext.Posts.FindAsync(postId);
//         if (post != null)
//         {
//             post.CommentCount += 1;
//             dbContext.Posts.Update(post);
//         }
        
//         await dbContext.SaveChangesAsync();
//         return comment.Id;
//     }
    
//     private StringContent CreateJsonContent<T>(T content)
//     {
//         var json = JsonSerializer.Serialize(content);
//         return new StringContent(json, Encoding.UTF8, "application/json");
//     }
    
//     [Fact]
//     public async Task CreateComment_ValidData_ReturnsSuccess()
//     {
//         // Arrange
//         await _factory.AuthenticateClientAsync(_client, _testUserIdGuid.ToString());
//         var postId = await SetupTestPostAsync();
//         var createCommentDto = new CreateCommentDto { Content = "New test comment" };
        
//         // Act
//         var response = await _client.PostAsync(
//             $"/api/Comments/{postId}", 
//             CreateJsonContent(createCommentDto));
        
//         // Assert
//         response.EnsureSuccessStatusCode();
//         var result = await response.Content.ReadFromJsonAsync<ApiResponse<bool>>();
//         Assert.NotNull(result);
//         Assert.True(result.Data);
//         Assert.Contains("Comment created successfully", result.Message);
        
//         // Verify in database
//         using var scope = _factory.Services.CreateScope();
//         var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//         var commentExists = await dbContext.Comments
//             .AnyAsync(c => c.PostId == postId && c.Content == createCommentDto.Content);
//         Assert.True(commentExists);
//     }
    
//     [Fact]
//     public async Task CreateComment_AsReply_ReturnsSuccess()
//     {
//         // Arrange
//         await _factory.AuthenticateClientAsync(_client, _testUserIdGuid.ToString());
//         var postId = await SetupTestPostAsync();
//         var parentCommentId = await CreateTestCommentAsync(postId);
//         var createCommentDto = new CreateCommentDto 
//         { 
//             Content = "Reply to comment", 
//             ParentCommentId = parentCommentId 
//         };
        
//         // Act
//         var response = await _client.PostAsync(
//             $"/api/Comments/{postId}", 
//             CreateJsonContent(createCommentDto));
        
//         // Assert
//         response.EnsureSuccessStatusCode();
//         var result = await response.Content.ReadFromJsonAsync<ApiResponse<bool>>();
//         Assert.NotNull(result);
//         Assert.True(result.Data);
        
//         // Verify in database
//         using var scope = _factory.Services.CreateScope();
//         var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//         var reply = await dbContext.Comments
//             .FirstOrDefaultAsync(c => c.ParentCommentId == parentCommentId && c.Content == createCommentDto.Content);
//         Assert.NotNull(reply);
        
//         // Verify parent comment reply count increased
//         var parentComment = await dbContext.Comments.FindAsync(parentCommentId);
//         Assert.NotNull(parentComment);
//         Assert.True(parentComment.ReplyCount > 0);
//     }
    
//     [Fact]
//     public async Task CreateComment_Unauthorized_ReturnsUnauthorized()
//     {
//         // Arrange - not authenticating client
//         var postId = await SetupTestPostAsync();
//         var createCommentDto = new CreateCommentDto { Content = "Should not be created" };
        
//         // Act
//         var response = await _client.PostAsync(
//             $"/api/Comments/{postId}", 
//             CreateJsonContent(createCommentDto));
        
//         // Assert
//         Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
//     }
    
//     [Fact]
//     public async Task GetPostCommentsRoot_ReturnsComments()
//     {
//         // Arrange
//         await _factory.AuthenticateClientAsync(_client, _testUserIdGuid.ToString());
//         var postId = await SetupTestPostAsync();
        
//         // Create multiple comments
//         await CreateTestCommentAsync(postId);
//         await CreateTestCommentAsync(postId);
//         await CreateTestCommentAsync(postId);
        
//         // Act
//         var response = await _client.GetAsync($"/api/Comments/posts/{postId}");
        
//         // Assert
//         response.EnsureSuccessStatusCode();
//         var result = await response.Content.ReadFromJsonAsync<ApiResponse<PagedResult<CommentDto>>>();
//         Assert.NotNull(result);
//         Assert.NotNull(result.Data);
//         Assert.Equal(3, result.Data.Items.Count);
//     }
    
//     [Fact]
//     public async Task GetCommentReplies_ReturnsReplies()
//     {
//         // Arrange
//         await _factory.AuthenticateClientAsync(_client, _testUserIdGuid.ToString());
//         var postId = await SetupTestPostAsync();
//         var parentCommentId = await CreateTestCommentAsync(postId);
        
//         // Create multiple replies
//         await CreateTestCommentAsync(postId, parentCommentId);
//         await CreateTestCommentAsync(postId, parentCommentId);
        
//         // Act
//         var response = await _client.GetAsync($"/api/Comments/replies/{parentCommentId}");
        
//         // Assert
//         response.EnsureSuccessStatusCode();
//         var result = await response.Content.ReadFromJsonAsync<ApiResponse<PagedResult<CommentDto>>>();
//         Assert.NotNull(result);
//         Assert.NotNull(result.Data);
//         Assert.Equal(2, result.Data.Items.Count);
//     }
    
//     [Fact]
//     public async Task GetCommentById_ReturnsComment()
//     {
//         // Arrange
//         await _factory.AuthenticateClientAsync(_client, _testUserIdGuid.ToString());
//         var postId = await SetupTestPostAsync();
//         var commentId = await CreateTestCommentAsync(postId);
        
//         // Act
//         var response = await _client.GetAsync($"/api/Comments/{commentId}");
        
//         // Assert
//         response.EnsureSuccessStatusCode();
//         var result = await response.Content.ReadFromJsonAsync<ApiResponse<CommentDto>>();
//         Assert.NotNull(result);
//         Assert.NotNull(result.Data);
//         Assert.Equal(commentId, result.Data.Id);
//         Assert.Equal(postId, result.Data.PostId);
//     }
    
//     [Fact]
//     public async Task UpdateComment_ValidData_ReturnsSuccess()
//     {
//         // Arrange
//         await _factory.AuthenticateClientAsync(_client, _testUserIdGuid.ToString());
//         var postId = await SetupTestPostAsync();
//         var commentId = await CreateTestCommentAsync(postId);
//         var updateCommentDto = new UpdateCommentDto { Content = "Updated comment content" };
        
//         // Act
//         var response = await _client.PutAsync(
//             $"/api/Comments/{commentId}", 
//             CreateJsonContent(updateCommentDto));
        
//         // Assert
//         response.EnsureSuccessStatusCode();
//         var result = await response.Content.ReadFromJsonAsync<ApiResponse<bool>>();
//         Assert.NotNull(result);
//         Assert.True(result.Data);
        
//         // Verify in database
//         using var scope = _factory.Services.CreateScope();
//         var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//         var updatedComment = await dbContext.Comments.FindAsync(commentId);
//         Assert.NotNull(updatedComment);
//         Assert.Equal(updateCommentDto.Content, updatedComment.Content);
//     }
    
//     [Fact]
//     public async Task UpdateComment_NotOwner_ReturnsForbidden()
//     {
//         // Arrange
//         var postId = await SetupTestPostAsync();
//         var commentId = await CreateTestCommentAsync(postId);
        
//         // Authenticate as different user
//         await _factory.AuthenticateClientAsync(_client, _otherUserIdGuid.ToString());
        
//         var updateCommentDto = new UpdateCommentDto { Content = "Should not update" };
        
//         // Act
//         var response = await _client.PutAsync(
//             $"/api/Comments/{commentId}", 
//             CreateJsonContent(updateCommentDto));
        
//         // Assert
//         Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
//     }
    
//     [Fact]
//     public async Task DeleteComment_OwnerUser_ReturnsSuccess()
//     {
//         // Arrange
//         await _factory.AuthenticateClientAsync(_client, _testUserIdGuid.ToString());
//         var postId = await SetupTestPostAsync();
//         var commentId = await CreateTestCommentAsync(postId);
        
//         // Act
//         var response = await _client.DeleteAsync($"/api/Comments/{commentId}");
        
//         // Assert
//         response.EnsureSuccessStatusCode();
//         var result = await response.Content.ReadFromJsonAsync<ApiResponse<bool>>();
//         Assert.NotNull(result);
//         Assert.True(result.Data);
        
//         // Verify deletion in database
//         using var scope = _factory.Services.CreateScope();
//         var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//         var comment = await dbContext.Comments.FindAsync(commentId);
//         Assert.Null(comment);
//     }
    
//     [Fact]
//     public async Task DeleteComment_WithReplies_DeletesAllReplies()
//     {
//         // Arrange
//         await _factory.AuthenticateClientAsync(_client, _testUserIdGuid.ToString());
//         var postId = await SetupTestPostAsync();
//         var parentCommentId = await CreateTestCommentAsync(postId);
        
//         // Create some replies
//         var reply1Id = await CreateTestCommentAsync(postId, parentCommentId);
//         var reply2Id = await CreateTestCommentAsync(postId, parentCommentId);
        
//         // Act
//         var response = await _client.DeleteAsync($"/api/Comments/{parentCommentId}");
        
//         // Assert
//         response.EnsureSuccessStatusCode();
        
//         // Verify all comments are deleted
//         using var scope = _factory.Services.CreateScope();
//         var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//         var parentComment = await dbContext.Comments.FindAsync(parentCommentId);
//         var reply1 = await dbContext.Comments.FindAsync(reply1Id);
//         var reply2 = await dbContext.Comments.FindAsync(reply2Id);
        
//         Assert.Null(parentComment);
//         Assert.Null(reply1);
//         Assert.Null(reply2);
        
//         // Verify post comment count is updated
//         var post = await dbContext.Posts.FindAsync(postId);
//         Assert.NotNull(post);
//         Assert.Equal(0, post.CommentCount);
//     }

//     [Fact]
//     public async Task DeleteComment_NotOwner_ReturnsForbidden()
//     {
//         // Arrange
//         var postId = await SetupTestPostAsync();
//         var commentId = await CreateTestCommentAsync(postId);
        
//         // Authenticate as different user
//         await _factory.AuthenticateClientAsync(_client, _otherUserIdGuid.ToString());
        
//         // Act
//         var response = await _client.DeleteAsync($"/api/Comments/{commentId}");
        
//         // Assert
//         Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
//     }
// }