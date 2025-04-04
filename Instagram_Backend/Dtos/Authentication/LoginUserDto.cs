using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;

namespace Instagram_Backend.Dtos.Authentication ;


public class LoginUserDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    public bool RememberMe { get; set; }

    // the url that the user was trying to accesss before auth 
    public string? ReturnUrl { get; set; }
    public IList<AuthenticationScheme>? ExternalLogins { get; set; }
}