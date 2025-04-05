

namespace Instagram_Backend.Abstracts;
using Instagram_Backend.Dtos;
using Instagram_Backend.Dtos.Comments;

public interface IUserService
{
    Task<List<UserDto>> GetMyFollowers(string searchTerm, int page, int pageSize);
    Task<List<UserDto>> GetMyFollowing(string searchTerm, int page, int pageSize);
    Task<bool> FollowUser(Guid userId);
    Task<bool> UnfollowUser(Guid userId);
    
    // Task<bool> BlockUser(Guid userId);
    // Task<bool> UnblockUser(Guid userId);
}