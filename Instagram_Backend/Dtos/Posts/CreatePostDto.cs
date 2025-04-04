namespace Instagram_Backend.Dtos.Posts;
public class CreatePostDto
{
    public string Caption { get; set; } = string.Empty;
    // user will be set from token
    // posts will be sent as IFormFile
}