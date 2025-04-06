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


    public static User Create(string email, string firstName, string lastName , string username)
    {
        return new User
        {
            Email = email,
            UserName = username,
            FirstName = firstName,
            LastName = lastName
        };
    }
    
    public override string ToString()
    {
        return FirstName + " " + LastName;
    }

    public ICollection<Post> Posts { get; set; } = new List<Post>();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public ICollection<Like> Likes { get; set; } = new List<Like>();
    public ICollection<User> Followers { get; set; } = new List<User>();
    public ICollection<User> Following { get; set; } = new List<User>();
    
    
    // public ICollection<User> BlockedUser { get; set; } = new List<User>();
    // public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    // public ICollection<FollowRequest> FollowRequests { get; set; } = new List<FollowRequest>();
    // public ICollection<Story> Stories { get; set; } = new List<Story>();
    // public ICollection<StoryView> StoryViews { get; set; } = new List<StoryView>();
    // public ICollection<DirectMessage> SentMessages { get; set; } = new List<DirectMessage>();
    // public ICollection<DirectMessage> ReceivedMessages { get; set; } = new List<DirectMessage>();
    // public ICollection<DirectMessageGroup> DirectMessageGroups { get; set; } = new List<DirectMessageGroup>();
    
}