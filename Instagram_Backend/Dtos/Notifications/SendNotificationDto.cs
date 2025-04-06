using System;

namespace Instagram_Backend.Dtos.Notifications;
public enum NotificationType
{
    Like,
    Comment,
    Follow
    // Mention,
    // TaggedInPost
}

public class SendNotificationDto
{
    public Guid UserId { get; set; } // the user who will receive the notification
    // the id of the triggering user will be taken from the token
    
    public NotificationType Type { get; set; }
    public string Content { get; set; } = string.Empty;
    
    // either a post or a comment or none (  follow notification)
    // depending on the type of notification
    public Guid? PostId { get; set; }
    
    public Guid? CommentId { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
