namespace Instagram_Backend.Dtos.Comments;

public class CreateCommentDto
{
     // CommentId will come from route parameter
    public string Content { get; set; } = string.Empty;
}