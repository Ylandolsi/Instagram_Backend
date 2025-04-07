namespace Instagram_Backend.Models;

public class Comment
{
    public Guid Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public Guid PostId { get; set; }
    public Post Post { get; set; } = null!;
    
    public int LikeCount { get; set; } = 0;
    
    public int ReplyCount { get; set; } = 0;


    public Guid? ParentCommentId { get; set; }
    public Comment? ParentComment { get; set; }
}