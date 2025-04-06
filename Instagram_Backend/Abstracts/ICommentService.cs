using Instagram_Backend.Dtos;
using Instagram_Backend.Dtos.Comments;

namespace Instagram_Backend.Abstracts;

public interface ICommentService
{
    Task<bool> CreateCommentAsync(CreateCommentDto createCommentDto ,Guid PostId ,  Guid userId);
    Task<CommentDto> GetCommentByIdAsync(Guid commentId);
    Task<PagedResult<CommentDto>> GetPostCommentsAsync(Guid postId, int page, int pageSize, bool rootCommentsOnly = true);
    Task<PagedResult<CommentDto>> GetCommentRepliesAsync(Guid commentId, int page, int pageSize);
    Task<CommentDto> UpdateCommentAsync(UpdateCommentDto updateCommentDto , Guid commentId,  Guid userId);
    Task <bool> DeleteCommentAsync(Guid commentId , Guid userId);
}