using Instagram_Backend.Abstracts;
using Instagram_Backend.Models;
using Instagram_Backend.Requests;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Instagram_Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;
    private readonly IAuthTokenProcessor _authTokenProcessor;
    private readonly SignInManager<User> _signInManager;

    public AccountController(
        IAccountService accountService, 
        IAuthTokenProcessor authTokenProcessor,
        SignInManager<User> signInManager )
    {
        _accountService = accountService;
        _authTokenProcessor = authTokenProcessor;
        _signInManager = signInManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
    {
        if (registerRequest == null || !ModelState.IsValid)
        {
            return BadRequest("Invalid request");
        }

        await _accountService.RegisterAsync(registerRequest);
        return Ok(new { message = "User registered successfully" });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        if (loginRequest == null || !ModelState.IsValid)
        {
            return BadRequest("Invalid request");
        }
        await _accountService.LoginAsync(loginRequest);
        return Ok(new { message = "User logged in successfully" });
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshToken()
    {
        var refreshToken = Request.Cookies["REFRESH_TOKEN"];
        await _accountService.RefreshTokenAsync(refreshToken);
        return Ok(new { message = "Token refreshed successfully" });
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
            return Unauthorized();
        }

        await _accountService.LoginWithGoogleAsync(result.Principal);
        return Redirect(returnUrl ?? "/");
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await _accountService.LogoutAsync();
        return Ok(new { message = "User logged out successfully" });
    }
}