using System.Net;
using System.Net.Http.Json;
using Xunit;
using Instagram_Backend.Requests;

namespace IntegrationTest;

public class AuthenticationTests
{
    private readonly InstagramWebApplicationFactory _factory;
    private readonly HttpClient _client;
    
    public AuthenticationTests()
    {
        _factory = new InstagramWebApplicationFactory();
        _client = _factory.CreateClient();
    }

    [Fact]
    public async Task Register_WithValidData_ReturnsSuccess()
    {
        // Arrange
        var register = new RegisterRequest
        {
            FirstName = "Test",
            LastName = "User",
            Email = "testUser@gmail.com",
            Password = "P@ssword1",
            ConfirmPassword = "P@ssword1"
        };
        
        // Act
        var response = await _client.PostAsJsonAsync("/api/account/register", register);
        
        // Get response content to help with debugging
        var content = await response.Content.ReadAsStringAsync();
        
        // Assert with better error message
        Assert.Equal(
            HttpStatusCode.OK, 
            response.StatusCode        );
    }

    [Fact]
    public async Task Register_WithInvalidEmail_ReturnsBadRequest()
    {
        // Arrange
        var register = new RegisterRequest
        {
            FirstName = "Test",
            LastName = "User",
            Email = "invalid-email",
            Password = "P@ssword1",
            ConfirmPassword = "P@ssword1"
        };
        
        var response = await _client.PostAsJsonAsync("/api/account/register", register);
        
        var content = await response.Content.ReadAsStringAsync();
        
        Assert.Equal(
            HttpStatusCode.BadRequest, 
            response.StatusCode);
    }
    [Fact]
    public async Task RegisterThenLogin_WithValidCredentials_ReturnsSuccess()
    {
        string uniqueEmail = $"testuser_{Guid.NewGuid()}@example.com";
        
        var registerRequest = new RegisterRequest
        {
            FirstName = "Test",
            LastName = "User",
            Email = uniqueEmail,
            Password = "P@ssword1",
            ConfirmPassword = "P@ssword1"
        };
        
        var registerResponse = await _client.PostAsJsonAsync("/api/account/register", registerRequest);
        
        Assert.Equal(HttpStatusCode.OK, registerResponse.StatusCode);
        
        var loginRequest = new LoginRequest
        {
            Email = uniqueEmail,
            Password = "P@ssword1"
        };
        
        var loginResponse = await _client.PostAsJsonAsync("/api/account/login", loginRequest);
        
        Assert.Equal(HttpStatusCode.OK, loginResponse.StatusCode);
    }
    [Fact]
    public async Task LoginFailed(){
        var loginRequest = new LoginRequest
        {
            Email = "email@example.com",
            Password = "123"
        };
        var response = await _client.PostAsJsonAsync("/api/account/login", loginRequest);
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}