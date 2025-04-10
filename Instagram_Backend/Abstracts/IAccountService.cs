using System.Security.Claims;
using Instagram_Backend.Dtos;
using Instagram_Backend.Requests;

namespace Instagram_Backend.Abstracts;

public interface IAccountService
{
    Task<UserDto> GetUserDataAsync(Guid userId);
    Task RegisterAsync(RegisterRequest registerRequest);
    Task LoginAsync(LoginRequest loginRequest);
    Task RefreshTokenAsync(string? refreshToken);
    Task LoginWithGoogleAsync(ClaimsPrincipal? claimsPrincipal);

    Task LogoutAsync();

    Task<bool> VerifyEmailExistsAsync(string email) ; 
    Task<bool> VerifyUsernameExistsAsync(string username) ;
}