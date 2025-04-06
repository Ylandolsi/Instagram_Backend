// using System.Net;
// using System.Net.Http.Json;
// using System.Security.Claims;
// using Instagram_Backend.Dtos;
// using Instagram_Backend.Dtos.Notifications;
// using Instagram_Backend.Models;
// using Microsoft.AspNetCore.Authentication;
// using Microsoft.Extensions.DependencyInjection;
// using Xunit;

// namespace IntegrationTest;

// public class NotificationsTests
// {
//     private readonly InstagramWebApplicationFactory _factory;
//     private readonly HttpClient _client;
//     private readonly Guid _testUserId = Guid.NewGuid();
    
//     public NotificationsTests()
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
//     public async Task GetNotifications_ReturnsOkResult()
//     {
//         // Act
//         var response = await _client.GetAsync("/api/notifications?page=1&pageSize=10");
        
//         // Assert
//         response.EnsureSuccessStatusCode();
//         Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        
//         // Deserialize and verify content structure
//         var result = await response.Content.ReadFromJsonAsync<List<NotificationDto>>();
//         Assert.NotNull(result);
//     }
    
//     [Fact]
//     public async Task DeleteNotification_WithValidId_ReturnsNoContent()
//     {
//         // Arrange
//         var notificationId = await CreateTestNotification();
        
//         // Act
//         var response = await _client.DeleteAsync($"/api/notifications/{notificationId}");
        
//         // Assert
//         Assert.Equal(HttpStatusCode.OK, response.StatusCode);
//     }
    
//     [Fact]
//     public async Task MarkAsRead_WithValidId_ReturnsNoContent()
//     {
//         // Arrange
//         var notificationId = await CreateTestNotification();
        
//         // Act
//         var response = await _client.PatchAsync($"/api/notifications/{notificationId}/read", null);
        
//         // Assert
//         Assert.Equal(HttpStatusCode.OK, response.StatusCode);
//     }
    
//     [Fact]
//     public async Task MarkAllAsRead_ReturnsOk()
//     {
//         // Act
//         var response = await _client.PatchAsync("/api/notifications/read-all", null);
        
//         // Assert
//         Assert.Equal(HttpStatusCode.OK, response.StatusCode);
//     }
    
//     private async Task<Guid> CreateTestNotification()
//     {
//         // Use the DbContext directly to create a test notification
//         using var scope = _factory.Services.CreateScope();
//         var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        
//         var notification = new Notification
//         {
//             Id = Guid.NewGuid(),
//             UserId = _testUserId,
//             ActorId = Guid.NewGuid(),
//             Type = NotificationType.Like,
//             Content = "Test notification",
//             CreatedAt = DateTime.UtcNow
//         };
        
//         db.Notifications.Add(notification);
//         await db.SaveChangesAsync();
        
//         return notification.Id;
//     }
// }