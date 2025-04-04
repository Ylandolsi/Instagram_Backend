namespace Instagram_Backend.Dtos;

public class UserDto
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string ProfilePictureUrl { get; set; } = string.Empty;
}