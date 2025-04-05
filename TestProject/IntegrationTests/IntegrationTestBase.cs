// using System.Net.Http.Headers;
// using System.Net.Http.Json;
// using Instagram_Backend.Database;
// using Microsoft.AspNetCore.Mvc.Testing;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.DependencyInjection;

// namespace TestProject.IntegrationTests;

// internal class IntegrationTestBase : IClassFixture<WebApplicationFactory<Program>>
// {
//     private readonly WebApplicationFactory<Program> _factory;
//     private readonly HttpClient _client;

//     internal IntegrationTestBase(WebApplicationFactory<Program> factory)
//     {
//         _factory = factory.WithWebHostBuilder(builder =>
//         {
//             builder.ConfigureServices(services =>
//             {
//                 // Replace the real db context with in-memory database
//                 var descriptor = services.SingleOrDefault(
//                     d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
                
//                 if (descriptor != null)
//                 {
//                     services.Remove(descriptor);
//                 }
                
//                 services.AddDbContext<ApplicationDbContext>(options =>
//                 {
//                     options.UseInMemoryDatabase("InstagramTestDb");
//                 });
                
//                 // Initialize the test database with data
//                 var sp = services.BuildServiceProvider();
//                 using var scope = sp.CreateScope();
//                 var scopedServices = scope.ServiceProvider;
//                 var db = scopedServices.GetRequiredService<ApplicationDbContext>();
                
//                 // Ensure database is created
//                 db.Database.EnsureCreated();
//             });
//         });
        
//         // Create client with cookie handling enabled
//         _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
//         {
//             HandleCookies = true // Important for cookie-based auth
//         });
//     }
    
//     protected async Task AuthenticateAsync()
//     {
//         // Register a test user
//         var registrationResponse = await _client.PostAsJsonAsync("/api/account/register", new
//         {
//             Email = "test@example.com",
//             FirstName = "Test",
//             LastName = "User",
//             Username = "testuser",
//             Password = "P@ssword1",
//             ConfirmPassword = "P@ssword1"
//         });
        
//         registrationResponse.EnsureSuccessStatusCode();
        
//         // Login to set auth cookies
//         var loginResponse = await _client.PostAsJsonAsync("/api/account/login", new
//         {
//             Email = "test@example.com",
//             Password = "P@ssword1"
//         });
        
//         loginResponse.EnsureSuccessStatusCode();
        
//         // No need to extract tokens or set Authorization header
//         // The HttpClient will automatically send cookies on subsequent requests
//     }
// }