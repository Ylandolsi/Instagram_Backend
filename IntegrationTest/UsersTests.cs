// using System.Net;
// using System.Net.Http.Json;
// using System.Security.Claims;
// using Instagram_Backend.Dtos;
// using Instagram_Backend.Models;
// using Microsoft.Extensions.DependencyInjection;
// using Xunit;

// namespace IntegrationTest;

// public class UsersTests
// {
//     private readonly InstagramWebApplicationFactory _factory;
//     private readonly HttpClient _client;
//     private readonly Guid _testUserId = Guid.NewGuid();
    
//     public UsersTests()
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
//     public async Task GetFollowers_ReturnsOkResult()
//     {
//         // Arrange
//         var targetUserId = await CreateTestUser();
//         await CreateTestFollower(targetUserId);
        
//         // Act
//         var response = await _client.GetAsync($"/api/users/{targetUserId}/followers?page=1&pageSize=10");
        
//         // Assert
//         response.EnsureSuccessStatusCode();
//         var result = await response.Content.ReadFromJsonAsync<ApiResponse<PagedResult<UserDto>>>();
//         Assert.NotNull(result);
//     }
    
//     [Fact]
//     public async Task FollowUser_ReturnsOkResult()
//     {
//         // Arrange
//         var targetUserId = await CreateTestUser();
        
//         // Act
//         var response = await _client.PostAsync($"/api/users/{targetUserId}/follow", null);
        
//         // Assert
//         response.EnsureSuccessStatusCode();
//         var result = await response.Content.ReadFromJsonAsync<ApiResponse<object>>();
//         Assert.NotNull(result);
//     }
    
//     [Fact]
//     public async Task UnfollowUser_ReturnsOkResult()
//     {
//         // Arrange
//         var targetUserId = await CreateTestUser();
//         await _client.PostAsync($"/api/users/{targetUserId}/follow", null);
        
//         // Act
//         var response = await _client.PostAsync($"/api/users/{targetUserId}/unfollow", null);
        
//         // Assert
//         response.EnsureSuccessStatusCode();
//         var result = await response.Content.ReadFromJsonAsync<ApiResponse<object>>();
//         Assert.NotNull(result);
//     }
    
//     private async Task<Guid> CreateTestUser()
//     {
//         using var scope = _factory.Services.CreateScope();
//         var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        
//         var userId = Guid.NewGuid();
//         var user = new User
//         {
//             Id = userId,
//             UserName = $"testuser_{userId}",
//             Email = $"testuser_{userId}@example.com",
//             EmailConfirmed = true
//         };
        
//         db.Users.Add(user);
//         await db.SaveChangesAsync();
        
//         return userId;
//     }
    
//     private async Task CreateTestFollower(Guid targetUserId)
//     {
//         using var scope = _factory.Services.CreateScope();
//         var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        
//         var follow = new UserFollow
//         {
//             FollowerId = _testUserId,
//             FollowingId = targetUserId
//         };
        
//         db.UserFollows.Add(follow);
//         await db.SaveChangesAsync();
//     }
// }