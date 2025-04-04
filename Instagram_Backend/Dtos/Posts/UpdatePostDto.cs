namespace Instagram_Backend.Dtos.Posts;
public class UpdatePostDto
{
    // post id will be set from route parameter
    public string Caption { get; set; } = string.Empty;

}