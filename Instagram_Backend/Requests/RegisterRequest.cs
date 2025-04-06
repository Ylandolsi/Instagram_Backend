using System.ComponentModel.DataAnnotations;

namespace Instagram_Backend.Requests;
public class RegisterRequest
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    [Required]
    public required string UserName {get; init ; }

    [EmailAddress]
    public required string Email { get; init; }

    [Required]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,}$", ErrorMessage = "Password must be at least 6 characters long and contain at least one uppercase letter, one lowercase letter, and one digit.")]
    public string Password { get; set; }
    [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
}