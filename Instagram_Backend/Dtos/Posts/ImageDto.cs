namespace Instagram_Backend.Dtos.Posts;

public class ImageDto
{
    public Guid Id { get; set; }
    public string Url { get; set; } = string.Empty;
    public int Order { get; set; }
}