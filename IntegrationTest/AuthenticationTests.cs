using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Instagram_Backend.Requests;
namespace IntegrationTest;

public class AuthenticationTests
{
    private readonly InstagramWebApplicationFactory _factory;
    private readonly HttpClient _client;

    private const string TestUserId = "ce95b43e-6587-480c-8ca6-9e217f0873fe";

    private const string OtherUserId = "a807c843-8b08-42a0-bec3-8e02ed7b4279";
    private readonly Guid _testUserIdGuid = Guid.Parse(TestUserId);
    private readonly Guid _otherUserIdGuid = Guid.Parse(OtherUserId);

    
    public AuthenticationTests()
    {
        _factory = new InstagramWebApplicationFactory();
        _client = _factory.CreateClient();
        // _factory.AuthenticateClient(_client, OtherUserId);

    }

    [Fact]
    public async Task Register_WithValidData_ReturnsSuccess()
    {
        // Arrange
        var register = new RegisterRequest
        {
            FirstName = "Test",
            LastName = "User",
            UserName = "testUser",
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
            UserName = "testUser",
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
    public async Task LoginFailed(){
        var loginRequest = new LoginRequest
        {
            Email = "email@example.com",
            Password = "123"
        };
        var response = await _client.PostAsJsonAsync("/api/account/login", loginRequest);
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task RegisterThenLogin_WithValidCredentials_ReturnsSuccess()
    {


        string uniqueEmail = $"testuser_{Guid.NewGuid()}@example.com";
        
        var registerRequest = new RegisterRequest
        {
            FirstName = "Test",
            LastName = "User",
            UserName = "testUser",
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

        _client.DefaultRequestHeaders.Clear();
        await _factory.AuthenticateClient(_client, "mmoon");

        var testAuth = await _client.GetAsync("/api/account/test");
        Assert.Equal(HttpStatusCode.OK, testAuth.StatusCode);   
        var testAuthContent = await testAuth.Content.ReadAsStringAsync();
        // Assert.Equal(TestUserId, testAuthContent);
        Assert.Equal("mmoon", testAuthContent);

        _client.DefaultRequestHeaders.Clear();
        await _factory.AuthenticateClient(_client, TestUserId);
    }
}

    
