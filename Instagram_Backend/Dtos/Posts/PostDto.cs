using Instagram_Backend.Dtos;
namespace Instagram_Backend.Dtos.Posts;
public class PostDto
{
    public Guid Id { get; set; }
    public string Caption { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public UserDto User { get; set; } = null!;
    public List<ImageDto> Images { get; set; } = new();
    public int CommentCount { get; set; }
    public int LikeCount { get; set; }
    public bool IsLikedByCurrentUser { get; set; }
}