namespace Instagram_Backend.Abstracts;
using Instagram_Backend.Dtos.Posts;
using Instagram_Backend.Models;


public interface IPostService
{
    Task<Post> CreatePostAsync(CreatePostDto postDto, Guid userId);
    Task<Post> UpdatePostAsync(UpdatePostDto postDto, Guid postId, Guid userId);
    Task<bool> DeletePostAsync(Guid postId, Guid userId);
    Task<Post> GetPostByIdAsync(Guid postId);
    Task<List<PostDto>> GetPostsByUserIdAsync(Guid userId , int page, int pageSize);
    Task<List<PostDto>> GetAllPostsAsync(int page, int pageSize);
}
