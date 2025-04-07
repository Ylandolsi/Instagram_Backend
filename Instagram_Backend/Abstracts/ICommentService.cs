using Instagram_Backend.Dtos;
using Instagram_Backend.Dtos.Comments;

namespace Instagram_Backend.Abstracts;

public interface ICommentService
{
    Task<bool> CreateCommentAsync(CreateCommentDto createCommentDto ,Guid PostId ,  Guid userId);
    Task<CommentDto> GetCommentByIdAsync(Guid commentId, Guid currentUserId  ) ;
    Task<PagedResult<CommentDto>> GetPostCommentsRootAsync(Guid postId, int page, int pageSize, Guid currentUserId );
    Task<PagedResult<CommentDto>> GetCommentRepliesAsync(Guid commentId, int page, int pageSize , Guid currentUserId );
    Task<CommentDto> UpdateCommentAsync(UpdateCommentDto updateCommentDto , Guid commentId,  Guid userId);
    Task <bool> DeleteCommentAsync(Guid commentId , Guid userId);
}