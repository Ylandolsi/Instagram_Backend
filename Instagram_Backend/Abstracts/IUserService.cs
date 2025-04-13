namespace Instagram_Backend.Abstracts;
using Instagram_Backend.Dtos;
using Instagram_Backend.Dtos.Comments;

public interface IUserService
{
    Task <UserDto> GetUserById(Guid id );
    Task<PagedResult<UserDto>> GetMyFollowers( int page, int pageSize , Guid userId);
    Task<PagedResult<UserDto>> GetMyFollowing( int page, int pageSize , Guid userId);
    Task<bool> FollowUser(Guid userId , Guid toFollowId );
    Task<bool> UnfollowUser(Guid userId , Guid toUnfollowId);
    Task<PagedResult<UserDto>> SearchUsersAsync(string query, int page, int pageSize, Guid currentUserId) ; 
    // Task<bool> BlockUser(Guid userId , Guid toBlockId);
    // Task<bool> UnblockUser(Guid userId , Guid toUnblockId);
}