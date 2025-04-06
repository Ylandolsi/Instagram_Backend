namespace Instagram_Backend.Abstracts;

using Instagram_Backend.Dtos;
using Instagram_Backend.Dtos.Posts;
using Instagram_Backend.Models;


public interface IPostService
{
    Task<bool> CreatePostAsync(CreatePostDto postDto, List<IFormFile> file  , Guid userId);
    Task<bool> UpdatePostAsync(UpdatePostDto postDto, Guid postId, Guid userId);
    Task<bool> DeletePostAsync(Guid postId, Guid userId);
    Task<PostDto> GetPostByIdAsync(Guid postId  ,  Guid CurrentUserId);
    Task<PagedResult<PostDto>> GetPostsByUserIdAsync(Guid userId , int page, int pageSize  ,Guid CurrentUserId); // profile
    Task<PagedResult<PostDto>> GetAllPostsAsync(int page, int pageSize , Guid CurrentUserId); // feed 
}
