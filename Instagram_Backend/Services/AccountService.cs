using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

using Instagram_Backend.Abstracts;
using Instagram_Backend.Database;
using Instagram_Backend.Exceptions;
using Instagram_Backend.Models;
using Instagram_Backend.Requests;
using Microsoft.EntityFrameworkCore;
using Instagram_Backend.Dtos;
using Instagram_Backend.Mappers;

namespace Instagram_Backend.Services;

public class AccountService : IAccountService
{
    private readonly IAuthTokenProcessor _authTokenProcessor;
    private readonly UserManager<User> _userManager;

    private readonly ApplicationDbContext _dbContext;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AccountService(IAuthTokenProcessor authTokenProcessor, UserManager<User> userManager , ApplicationDbContext dbContext , IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
        _dbContext = dbContext;
        _authTokenProcessor = authTokenProcessor;
        _userManager = userManager;
    }

    public async Task<UserDto> GetUserDataAsync(Guid userId)
    {
        var user = await _dbContext.Users
            .Include( x => x.FollowerRelationships)
            .Include( x=> x.FollowingRelationships)
            .Where(x => x.Id == userId)
            .Select(x => MapperDto.MapUserToDto(x))
            .FirstOrDefaultAsync();

        if (user == null)
        {
            throw new NotFoundException($"User with ID {userId} not found.");
        }

        return user;
    }

    public async Task RegisterAsync(RegisterRequest registerRequest)
    {
        var userExists = await _userManager.FindByEmailAsync(registerRequest.Email) != null;

        if (userExists)
        {
            throw new BadRequestException($"User Already Exists With email = { registerRequest.Email} ");
        }

        var user = User.Create(registerRequest.Email, registerRequest.FirstName, registerRequest.LastName , registerRequest.UserName);
        user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, registerRequest.Password);

        var result = await _userManager.CreateAsync(user);

        if (!result.Succeeded)
        {
            throw new InvalidOpException($"User Registration Failed With errors = {result.Errors.Select(x => x.Description) } ");
        }
    }

    public async Task LoginAsync(LoginRequest loginRequest)
    {
        var user = await _userManager.FindByEmailAsync(loginRequest.Email);

        if (user == null || !await _userManager.CheckPasswordAsync(user, loginRequest.Password))
        {
            throw new BadRequestException($"Password or email incorrect");
        }

        var (jwtToken, expirationDateInUtc) = _authTokenProcessor.GenerateJwtToken(user);
        var refreshTokenValue = _authTokenProcessor.GenerateRefreshToken();

        var refreshTokenExpirationDateInUtc = DateTime.UtcNow.AddDays(7);

        user.RefreshToken = refreshTokenValue;
        user.RefreshTokenExpiresAtUtc = refreshTokenExpirationDateInUtc;

        await _userManager.UpdateAsync(user);
        
        _authTokenProcessor.WriteAuthTokenAsHttpOnlyCookie("ACCESS_TOKEN", jwtToken, expirationDateInUtc);
        _authTokenProcessor.WriteAuthTokenAsHttpOnlyCookie("REFRESH_TOKEN", user.RefreshToken, refreshTokenExpirationDateInUtc);
    }

    public async Task RefreshTokenAsync(string? refreshToken)
    {
        if (string.IsNullOrEmpty(refreshToken))
        {
            throw new BadRequestException("Refresh token is missing.");
        }

        var user = await _dbContext.Users
            .FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);

        if (user == null)
        {
            throw new BadRequestException("Unable to retrieve user for refresh token");
        }

        if (user.RefreshTokenExpiresAtUtc < DateTime.UtcNow)
        {
            throw new BadRequestException("Refresh token is expired.");
        }
        
        var (jwtToken, expirationDateInUtc) = _authTokenProcessor.GenerateJwtToken(user);
        var refreshTokenValue = _authTokenProcessor.GenerateRefreshToken();

        var refreshTokenExpirationDateInUtc = DateTime.UtcNow.AddDays(7);

        user.RefreshToken = refreshTokenValue;
        user.RefreshTokenExpiresAtUtc = refreshTokenExpirationDateInUtc;

        await _userManager.UpdateAsync(user);
        
        _authTokenProcessor.WriteAuthTokenAsHttpOnlyCookie("ACCESS_TOKEN", jwtToken, expirationDateInUtc);
        _authTokenProcessor.WriteAuthTokenAsHttpOnlyCookie("REFRESH_TOKEN", user.RefreshToken, refreshTokenExpirationDateInUtc);
    }

    public async Task LoginWithGoogleAsync(ClaimsPrincipal? claimsPrincipal)
    {
        if (claimsPrincipal == null)
        {
            throw new Exception($"External login provider: {"Google"} error occurred: {"ClaimsPrincipal is null"}" );
        }
        
        var email = claimsPrincipal.FindFirstValue(ClaimTypes.Email);

        if (email == null)
        {
            throw new Exception($"External login provider: {"Google"} error occurred: {"Email is null"}" );
        }

        var user = await _userManager.FindByEmailAsync(email);

        if (user == null)
        {
            var newUser = new User
            {
                UserName = claimsPrincipal.FindFirstValue(ClaimTypes.GivenName) + claimsPrincipal.FindFirstValue(ClaimTypes.Surname) ?? string.Empty,
                Email = email,
                FirstName = claimsPrincipal.FindFirstValue(ClaimTypes.GivenName) ?? string.Empty,
                LastName = claimsPrincipal.FindFirstValue(ClaimTypes.Surname) ?? string.Empty,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(newUser);

            if (!result.Succeeded)
            {
                string errorOcc = $"Unable to create user: {string.Join(", ", result.Errors.Select(x => x.Description))}";
                throw new  Exception($"External login provider: \"Google\" error occurred: {errorOcc}");
            }

            

            user = newUser;
            var info = new UserLoginInfo("Google",
                claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty,
                "Google");

            var loginResult = await _userManager.AddLoginAsync(user, info);
                
            if (!loginResult.Succeeded)
            {
                string errorOcc = $"Unable to add login: {string.Join(", ", loginResult.Errors.Select(x => x.Description))}";
                throw new Exception($"External login provider: \"Google\" error occurred: {errorOcc}");
            }
        }
        
        
        var (jwtToken, expirationDateInUtc) = _authTokenProcessor.GenerateJwtToken(user);
        var refreshTokenValue = _authTokenProcessor.GenerateRefreshToken();

        var refreshTokenExpirationDateInUtc = DateTime.UtcNow.AddDays(7);

        user.RefreshToken = refreshTokenValue;
        user.RefreshTokenExpiresAtUtc = refreshTokenExpirationDateInUtc;

        await _userManager.UpdateAsync(user);
        
        _authTokenProcessor.WriteAuthTokenAsHttpOnlyCookie("ACCESS_TOKEN", jwtToken, expirationDateInUtc);
        _authTokenProcessor.WriteAuthTokenAsHttpOnlyCookie("REFRESH_TOKEN", user.RefreshToken, refreshTokenExpirationDateInUtc);
    }
    public async Task LogoutAsync()
    {
        var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        
        if (!string.IsNullOrEmpty(userId))
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                user.RefreshToken = null;
                user.RefreshTokenExpiresAtUtc = DateTime.UtcNow.AddMinutes(-1);
                await _userManager.UpdateAsync(user);
            }
        }
        
        _authTokenProcessor.ClearAuthTokenCookie("ACCESS_TOKEN");
        _authTokenProcessor.ClearAuthTokenCookie("REFRESH_TOKEN");
    }

    public async Task<bool>  VerifyEmailExistsAsync( string email){

        return await _dbContext.Users.Where( u => u.Email == email).FirstOrDefaultAsync() != null ; 
    }

    public async Task<bool> VerifyUsernameExistsAsync ( string username){
        return await _dbContext.Users.Where( u => u.UserName == username).FirstOrDefaultAsync() != null ; 
    }

}