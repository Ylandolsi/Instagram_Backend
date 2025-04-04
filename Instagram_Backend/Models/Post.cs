
namespace Instagram_Backend.Models;
public class Post
{
    public Guid Id { get; set; }
    public string Caption { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public ICollection<Image> Images { get; set; } = new List<Image>();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public ICollection<Like> Likes { get; set; } = new List<Like>();
}
