
namespace Instagram_Backend.Models ;

public class UserFollower {
    public Guid FollowingId { get; set; }
    public Guid FollowerId { get; set; }

    public User Follower{ get; set; }
    public User Following{ get; set; }
}