using Instagram_Backend.Abstracts;
using Instagram_Backend.Models;

namespace IntegrationTest.Mocks;

public class MockAuthTokenProcessor : IAuthTokenProcessor
{
    public (string jwtToken, DateTime expiresAtUtc) GenerateJwtToken(User user)
    {
        // Return mock JWT token and expiration time
        return ("mocked_jwt_token", DateTime.UtcNow.AddHours(1));
    }

    public string GenerateRefreshToken()
    {
        // Return mock refresh token
        return "mocked_refresh_token";
    }

    public void WriteAuthTokenAsHttpOnlyCookie(string cookieName, string token, DateTime expiration)
    {
        // Mock implementation, do nothing in tests
    }

    public void ClearAuthTokenCookie(string cookieName)
    {
        // Mock implementation, do nothing in tests
    }
}