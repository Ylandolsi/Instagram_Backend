
namespace Instagram_Backend.Models;
using System;

public enum LikeType
{
    Post,
    Comment
}

public class Like
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public LikeType Type { get; set; }
    
    public Guid? PostId { get; set; }
    public Post? Post { get; set; }
    public Guid? CommentId { get; set; }
    public Comment? Comment { get; set; }
}