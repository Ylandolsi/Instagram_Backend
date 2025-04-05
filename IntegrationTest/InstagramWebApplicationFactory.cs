using Instagram_Backend.Database;
using Instagram_Backend.Options;
using Instagram_Backend.Abstracts;
using Instagram_Backend.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Encodings.Web;
using IntegrationTest.Mocks ; 

namespace IntegrationTest;

internal class InstagramWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing");

        builder.ConfigureAppConfiguration((context, config) =>
        {
            // Add dummy Google auth settings that will be used during registration
            var testConfig = new Dictionary<string, string>
            {
                ["Authentication:Google:ClientId"] = "test-client-id",
                ["Authentication:Google:ClientSecret"] = "test-client-secret"
            };
            
            config.AddInMemoryCollection(testConfig);
        });
        

        
        builder.ConfigureServices(services =>
        {
            // Remove database context registration
            var dbContextDescriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
            if (dbContextDescriptor != null)
            {
                services.Remove(dbContextDescriptor);
            }
            
            // Create a separate service provider for EF
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();
                
            // Configure the database
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseInMemoryDatabase("TestingDb");
                options.UseInternalServiceProvider(serviceProvider);
            });
            
            // COMPLETELY REPLACE the authentication system
            
            // First remove all authentication related services
            RemoveAuthenticationServices(services);
            
            // Add minimal test authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "TestScheme";
                options.DefaultChallengeScheme = "TestScheme";
                options.DefaultScheme = "TestScheme";
            })
            .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>(
                "TestScheme", options => { });

            services.AddAuthorization();
                
            // Configure JWT options for tests
            services.Configure<JwtOptions>(options =>
            {
                options.Secret = "TestSecretKeyWithAtLeast32Characters!!";
                options.Issuer = "TestIssuer";
                options.Audience = "TestAudience";
                options.ExpirationTimeInMinutes = 30;
            });
            
            // Fix any dependency issues with Identity
            services.AddIdentityCore<User>()
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.AddSingleton<IAuthTokenProcessor, MockAuthTokenProcessor>();
                
            // Build new service provider to initialize test database
            using var scope = services.BuildServiceProvider().CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            
            try
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                // Seed data if needed
            }
            catch (Exception ex)
            {
                // Log the exception
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<InstagramWebApplicationFactory>>();
                logger.LogError(ex, "An error occurred while setting up the test database.");
            }
        });
    }
    
    private void RemoveAuthenticationServices(IServiceCollection services)
    {
        // Remove all authentication and authorization services
        var authServiceDescriptors = services
            .Where(descriptor => 
                descriptor.ServiceType.Namespace?.Contains("Authentication") == true ||
                descriptor.ImplementationType?.Namespace?.Contains("Authentication") == true ||
                descriptor.ServiceType.Name.Contains("Auth") ||
                descriptor.ImplementationType?.Name.Contains("Auth") == true)
            .ToList();
            
        foreach (var descriptor in authServiceDescriptors)
        {
            services.Remove(descriptor);
        }
    }
}
// thanks to the test authentication scheme && testAuthHandler : 
// it will always return a successful authentication result
// ==> means we can test endpoints ([Authorize]) without needing a real JWT token
public class TestAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    // instead of using a real authentication scheme, we create a test one
    // that will always return a successful authentication result
    public TestAuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, 
        ILoggerFactory logger, 
        UrlEncoder encoder, 
        ISystemClock clock) 
        : base(options, logger, encoder, clock)
    {
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, "Test User"),
            new Claim(JwtRegisteredClaimNames.Email, "test@example.com") ,

        };
        
        var identity = new ClaimsIdentity(claims, "TestScheme");
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, "TestScheme");

        return Task.FromResult(AuthenticateResult.Success(ticket));
    }
}