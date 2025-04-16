namespace Instagram_Backend.Models;

public enum NotificationType
{
    Like,
    Comment,
    Follow,

    // Mention,
    // TaggedInPost
}

public class Notification
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public Guid ActorId { get; set; }  // who triggered the notification
    public User Actor { get; set; } = null!;
    
    public NotificationType Type { get; set; }
    public string Content { get; set; } = string.Empty;
    
    // either a post or a comment or none (  follow notification)
    // depending on the type of notification
    public Guid? PostId { get; set; }
    public Post? Post { get; set; }
    
    public Guid? CommentId { get; set; }
    public Comment? Comment { get; set; }
    
    public bool IsRead { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}