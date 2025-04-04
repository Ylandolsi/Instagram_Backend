namespace Instagram_Backend.Models;

public class Comment
{
    public Guid Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public Guid PostId { get; set; }
    public Post Post { get; set; } = null!;
    public ICollection<Like> Likes { get; set; } = new List<Like>();
    
    public Guid? ParentCommentId { get; set; }
    public Comment? ParentComment { get; set; }
    public ICollection<Comment> Replies { get; set; } = new List<Comment>();
}