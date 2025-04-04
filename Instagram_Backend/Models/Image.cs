
namespace Instagram_Backend.Models;
public class Image
{
    public Guid Id { get; set; }
    public string Url { get; set; } = string.Empty;
    public int Order { get; set; }
    
    public Guid PostId { get; set; }
    public Post Post { get; set; } = null!;
}
