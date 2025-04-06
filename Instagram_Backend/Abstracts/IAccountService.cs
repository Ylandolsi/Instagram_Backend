using System.Security.Claims;
using Instagram_Backend.Requests;

namespace Instagram_Backend.Abstracts;

public interface IAccountService
{
    Task RegisterAsync(RegisterRequest registerRequest);
    Task LoginAsync(LoginRequest loginRequest);
    Task RefreshTokenAsync(string? refreshToken);
    Task LoginWithGoogleAsync(ClaimsPrincipal? claimsPrincipal);

    Task LogoutAsync();

    Task<bool> VerifyEmailExistsAsync(string email) ; 
    Task<bool> VerifyUsernameExistsAsync(string username) ;
}