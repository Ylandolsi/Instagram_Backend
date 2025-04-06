using Instagram_Backend.Dtos;
using Instagram_Backend.Dtos.Posts;

namespace Instagram_Backend.Abstracts; 
public interface ILikeService {
    
    Task<bool> ToggleLikePostAsync(Guid postId, Guid userId);
    Task<bool> ToggleLikeCommentAsync(Guid commentId, Guid userId);
    Task<bool> IsPostLikedByUserAsync(Guid postId, Guid userId);

    Task<bool> IsCommentLikedByUserAsync(Guid commentId, Guid userId);

    Task<PagedResult<UserDto>> GetUsersWhoLikedPostAsync(Guid postId , int pageNumber, int pageSize);
    Task<PagedResult<PostDto>> GetLikedPostsByUserAsync(Guid userId, int pageNumber , int pageSize); // can only be used by the user himself

}