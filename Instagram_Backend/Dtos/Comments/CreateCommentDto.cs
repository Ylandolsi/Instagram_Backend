namespace Instagram_Backend.Dtos.Comments;

public class CreateCommentDto
{
    public Guid PostId { get; set; }
    public string Content { get; set; } = string.Empty;
    public Guid? ParentCommentId { get; set; } 
}