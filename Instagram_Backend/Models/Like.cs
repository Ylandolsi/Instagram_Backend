
namespace Instagram_Backend.Models;

public class Like
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public string Type { get; set; } = string.Empty; // "Post" or "Comment"
    
    public Guid? PostId { get; set; }
    public Post? Post { get; set; }
    public Guid? CommentId { get; set; }
    public Comment? Comment { get; set; }
}