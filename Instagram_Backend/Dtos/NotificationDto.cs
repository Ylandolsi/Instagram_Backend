
using Instagram_Backend.Dtos;
using Instagram_Backend.Dtos.Comments;
using Instagram_Backend.Dtos.Posts;
using Instagram_Backend.Models;

public class NotificationDto
{
    public Guid Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsRead { get; set; } = false;

    public PostDto? Post { get; set; } = null!;
    public CommentDto? Comment { get; set; } = null!;
    public UserDto? User { get; set; } = null!;
}