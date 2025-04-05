using Instagram_Backend.Dtos;
using Instagram_Backend.Dtos.Comments;

namespace Instagram_Backend.Abstracts;

public interface ICommentService
{
    Task<CommentDto> GetCommentByIdAsync(Guid commentId);
    Task<PagedResult<CommentDto>> GetPostCommentsAsync(Guid postId, int page, int pageSize, bool rootCommentsOnly = true);
    Task<PagedResult<CommentDto>> GetCommentRepliesAsync(Guid commentId, int page, int pageSize);
    Task<CommentDto> CreateCommentAsync(CreateCommentDto createCommentDto , Guid userId);
    Task<CommentDto> CreateReplyAsync( CreateCommentDto createCommentDto , Guid parentCommentId, Guid userId);
    Task<CommentDto> UpdateCommentAsync(UpdateCommentDto updateCommentDto , Guid commentId,  Guid userId);
    Task DeleteCommentAsync(Guid commentId);
}