namespace Instagram_Backend.Dtos;

public class UserDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty; 
    public string ProfilePictureUrl { get; set; } = string.Empty;
}
