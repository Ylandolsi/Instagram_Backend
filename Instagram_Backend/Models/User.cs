using Microsoft.AspNetCore.Identity;

namespace Instagram_Backend.Models;

public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ProfilePictureUrl { get; set; }
    public string CoverPhotoUrl { get; set; }
    public string Bio { get; set; }
    
    
}