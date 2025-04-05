// using System.Net;
// using Instagram_Backend.Dtos.Comments;
// using Instagram_Backend.Dtos.Posts;
// using Microsoft.AspNetCore.Mvc.Testing;

// namespace TestProject.IntegrationTests;

// public class CommentIntegrationTests : IntegrationTestBase
// {
//     public CommentIntegrationTests(WebApplicationFactory<Program> factory) : base(factory)
//     {
//     }

//     [Fact]
//     public async Task AddCommentAndReply_ReturnsSuccessAndCorrectData()
//     {
//         // Arrange - Create authenticated client and a post
//         await AuthenticateAsync();
//         var post = await CreateTestPostAsync();
        
//         // Act - Add comment to post
//         var commentResponse = await _client.PostAsJsonAsync("/api/comments", new CreateCommentDto
//         {
//             PostId = post.Id,
//             Content = "This is a test comment"
//         });
        
//         // Assert - Comment created successfully
//         commentResponse.EnsureSuccessStatusCode();
//         var comment = await commentResponse.Content.ReadFromJsonAsync<CommentDto>();
//         Assert.NotNull(comment);
//         Assert.Equal("This is a test comment", comment.Content);
//         Assert.Equal(post.Id, comment.PostId);
        
//         // Act - Add reply to comment
//         var replyResponse = await _client.PostAsJsonAsync($"/api/comments/{comment.Id}/reply", new CreateCommentDto
//         {
//             PostId = post.Id,
//             Content = "This is a reply",
//             ParentCommentId = comment.Id
//         });
        
//         // Assert - Reply created successfully
//         replyResponse.EnsureSuccessStatusCode();
//         var reply = await replyResponse.Content.ReadFromJsonAsync<CommentDto>();
//         Assert.NotNull(reply);
//         Assert.Equal("This is a reply", reply.Content);
//         Assert.Equal(comment.Id, reply.ParentCommentId);
        
//         // Act - Get comments for post including replies
//         var getCommentsResponse = await _client.GetAsync($"/api/comments/post/{post.Id}?rootCommentsOnly=false");
        
//         // Assert - Comments retrieved correctly
//         getCommentsResponse.EnsureSuccessStatusCode();
//         var commentsResult = await getCommentsResponse.Content.ReadFromJsonAsync<PagedResult<CommentDto>>();
//         Assert.NotNull(commentsResult);
//         Assert.Equal(1, commentsResult.Items.Count); // One root comment
//         Assert.Equal(1, commentsResult.Items[0].ReplyCount); // With one reply
//     }
    
//     private async Task<PostDto> CreateTestPostAsync()
//     {
//         // Create a basic test post
//         var postResponse = await _client.PostAsJsonAsync("/api/posts", new CreatePostDto
//         {
//             Caption = "Test post for comments"
//         });
        
//         postResponse.EnsureSuccessStatusCode();
//         return await postResponse.Content.ReadFromJsonAsync<PostDto>();
//     }
// }