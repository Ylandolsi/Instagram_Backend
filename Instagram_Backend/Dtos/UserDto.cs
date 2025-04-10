namespace Instagram_Backend.Dtos;

public class UserDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty; 
    public string ProfilePictureUrl { get; set; } = string.Empty;
    public bool IsFollowedByCurrentUser { get; set; } = false;
    public string Bio { get; set; } = string.Empty;
    public int FollowersCount { get; set; } = 0;
    public int FollowingCount { get; set; } = 0;

    //  we have to add ( bio , followers , following ,  profilepicture )
    // apply changes to LikeService && UserService
}
