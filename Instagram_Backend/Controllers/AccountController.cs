using System.Security.Claims;
using Instagram_Backend.Abstracts;
using Instagram_Backend.Models;
using Instagram_Backend.Requests;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Instagram_Backend.Controllers;

using JWTtokens = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames ;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;
    private readonly IAuthTokenProcessor _authTokenProcessor;
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;

    public AccountController(
        IAccountService accountService, 
        IAuthTokenProcessor authTokenProcessor,
        SignInManager<User> signInManager  , UserManager<User> userManager)
    {
        _userManager = userManager;
        _accountService = accountService;
        _authTokenProcessor = authTokenProcessor;
        _signInManager = signInManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
    {
        if (registerRequest == null || !ModelState.IsValid)
        {
            return BadRequest(new ApiResponse<bool>
            {
                Message = "Invalid request",
                Data = false,
            });
        }

        await _accountService.RegisterAsync(registerRequest);
        return Ok(new ApiResponse<bool>
        {
            Message = "User registered successfully",
            Data = true,
        });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        if (loginRequest == null || !ModelState.IsValid)
        {
            return BadRequest(new ApiResponse<bool>
            {
                Message = "Invalid request",
                Data = false,
            });
        }
        await _accountService.LoginAsync(loginRequest);
        return Ok(new ApiResponse<bool>
        {
            Message = "User logged in successfully",
            Data = true,
        });
    }

    [HttpPost("refresh")]
    [Authorize]
    public async Task<IActionResult> RefreshToken()
    {
        var refreshToken = Request.Cookies["REFRESH_TOKEN"];
        await _accountService.RefreshTokenAsync(refreshToken);
        return Ok(new ApiResponse<bool>
        {
            Message = "Token refreshed successfully",
            Data = true,
        });
    }
    
    [HttpGet("login/google")]
    public IActionResult GoogleLogin([FromQuery] string returnUrl)
    {
        var properties = _signInManager.ConfigureExternalAuthenticationProperties(
            "Google",
            Url.Action(nameof(GoogleLoginCallback), "Account", new { returnUrl })
        );
        // force the user to select an account
        properties.SetParameter("prompt", "select_account");

        return Challenge(properties, new[] { "Google" });
    }

    [HttpGet("login/google/callback")]
    public async Task<IActionResult> GoogleLoginCallback([FromQuery] string returnUrl)
    {
        var result = await HttpContext.AuthenticateAsync("Google");
        if (!result.Succeeded)
        {
            return Unauthorized( new ApiResponse<bool>
            {
                Message = "Google login failed",
                Data = false,
            });
        }

        await _accountService.LoginWithGoogleAsync(result.Principal);
        return Redirect(returnUrl ?? "/");
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await _accountService.LogoutAsync();
        return Ok(new ApiResponse<bool>
        {
            Message = "User logged out successfully",
            Data = true,
        });
    }

    [HttpPost("verify/email")]
    public async Task<IActionResult> VerifyEmailExists(string email){
        if (string.IsNullOrEmpty(email))
        {
            return BadRequest(new ApiResponse<bool>
            {
                Message = "Email cannot be null or empty",
                Data = false,
            });
        }
        var exists = await _accountService.VerifyEmailExistsAsync(email); 
        return Ok(new ApiResponse<bool>
        {
            Message = $"Email = {email} {(exists ? "exists" : "does not exist")}" ,
            Data = exists ,
        }); 
    }

    [HttpPost("verify/username")] 
    public async Task<IActionResult> VerifyUsernameExists(string username){
        if (string.IsNullOrEmpty(username))
        {
            return BadRequest(new ApiResponse<bool>
            {
                Message = "Username cannot be null or empty",
                Data = false,
            });
        }
        var exists = await _accountService.VerifyUsernameExistsAsync(username); 
        return Ok(new ApiResponse<bool>
        {
            Message = $"Username = {username} {(exists ? "exists" : "does not exist")}" ,
            Data = exists ,
        }); 
    }

    // test 
    [HttpGet("test")]
    [Authorize]
    public IActionResult Test()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        return Ok(userId);
        // return Ok() ;
    }
}