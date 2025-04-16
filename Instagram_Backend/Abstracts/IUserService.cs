namespace Instagram_Backend.Abstracts;
using Instagram_Backend.Dtos;
using Instagram_Backend.Dtos.Comments;

public interface IUserService
{
    Task <UserDto> GetUserById(Guid id , Guid currentUserId );
    Task<PagedResult<UserDto>> GetMyFollowers( int page, int pageSize , Guid userId , Guid currentUserId);
    Task<PagedResult<UserDto>> GetMyFollowing( int page, int pageSize , Guid userId , Guid currentUserId);
    Task<bool> FollowUser(Guid userId , Guid toFollowId );
    Task<bool> UnfollowUser(Guid userId , Guid toUnfollowId);
    Task<PagedResult<UserDto>> SearchUsersAsync(string query, int page, int pageSize, Guid currentUserId) ; 
}