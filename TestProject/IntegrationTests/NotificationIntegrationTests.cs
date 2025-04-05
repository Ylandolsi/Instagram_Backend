// using System.Net.Http.Headers;
// using System.Net.Http.Json;
// using Instagram_Backend.Dtos.Posts;
// using Microsoft.AspNetCore.Mvc.Testing;

// namespace TestProject.IntegrationTests;

// public class NotificationIntegrationTests : IntegrationTestBase
// {
//     private readonly HttpClient _secondUserClient;
    
//     public NotificationIntegrationTests(WebApplicationFactory<Program> factory) : base(factory)
//     {
//         // Create a second client for testing interactions between users
//         _secondUserClient = factory.CreateClient();
//     }

//     [Fact]
//     public async Task LikePost_GeneratesNotification_AndCanBeRetrieved()
//     {
//         // Arrange - Set up users and create a post
//         await AuthenticateAsync(); // First user
//         var post = await CreateTestPostAsync();
        
//         // Register and authenticate second user
//         await RegisterAndAuthenticateSecondUserAsync();
        
//         // Act - Second user likes first user's post
//         var likeResponse = await _secondUserClient.PostAsync($"/api/likes/post/{post.Id}", null);
        
//         // Assert - Like successful
//         likeResponse.EnsureSuccessStatusCode();
        
//         // Give the system time to process the notification
//         await Task.Delay(500);
        
//         // Act - First user checks notifications
//         var notificationsResponse = await _client.GetAsync("/api/notifications");
        
//         // Assert - Notification received for the like
//         notificationsResponse.EnsureSuccessStatusCode();
//         var notifications = await notificationsResponse.Content
//             .ReadFromJsonAsync<List<NotificationDto>>();
        
//         Assert.NotNull(notifications);
//         Assert.Contains(notifications, n => 
//             n.Type == NotificationType.Like && 
//             n.PostId == post.Id &&
//             !n.IsRead);
//     }
    
//     private async Task RegisterAndAuthenticateSecondUserAsync()
//     {
//         // Register second test user
//         var registrationResponse = await _secondUserClient.PostAsJsonAsync("/api/account/register", new
//         {
//             Email = "second@example.com",
//             FirstName = "Second",
//             LastName = "User",
//             Username = "seconduser",
//             Password = "P@ssword1",
//             ConfirmPassword = "P@ssword1"
//         });
        
//         registrationResponse.EnsureSuccessStatusCode();
        
//         // Login second user
//         var loginResponse = await _secondUserClient.PostAsJsonAsync("/api/account/login", new
//         {
//             Email = "second@example.com",
//             Password = "P@ssword1"
//         });
        
//         loginResponse.EnsureSuccessStatusCode();
        
//         var loginResult = await loginResponse.Content.ReadFromJsonAsync<LoginResponseDto>();
//         _secondUserClient.DefaultRequestHeaders.Authorization = 
//             new AuthenticationHeaderValue("Bearer", loginResult.AccessToken);
//     }
    
//     private async Task<PostDto> CreateTestPostAsync()
//     {
//         // Create a basic test post
//         var postResponse = await _client.PostAsJsonAsync("/api/posts", new CreatePostDto
//         {
//             Caption = "Test post for notifications"
//         });
        
//         postResponse.EnsureSuccessStatusCode();
//         return await postResponse.Content.ReadFromJsonAsync<PostDto>();
//     }
// }