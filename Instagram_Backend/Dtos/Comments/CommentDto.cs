using Instagram_Backend.Dtos;
namespace Instagram_Backend.Dtos.Comments;

public class CommentDto
{
    public Guid Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public UserDto User { get; set; } = null!;
    public int LikeCount { get; set; }
    public bool IsLikedByCurrentUser { get; set; }
    
    // Nested comment properties
    public Guid? ParentCommentId { get; set; }
    public int ReplyCount { get; set; }
    public List<CommentDto>? Replies { get; set; }
}