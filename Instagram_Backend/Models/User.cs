using Microsoft.AspNetCore.Identity;

namespace Instagram_Backend.Models;

public class User : IdentityUser<Guid> // guid is used as the primary key type
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiresAtUtc { get; set; }
    public string ProfilePictureUrl { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;

    public ICollection<Post> Posts { get; set; } = new List<Post>();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public ICollection<Like> Likes { get; set; } = new List<Like>();
    
    public static User Create(string email, string firstName, string lastName)
    {
        return new User
        {
            Email = email,
            UserName = email,
            FirstName = firstName,
            LastName = lastName
        };
    }
    
    public override string ToString()
    {
        return FirstName + " " + LastName;
    }

    
    
    
}