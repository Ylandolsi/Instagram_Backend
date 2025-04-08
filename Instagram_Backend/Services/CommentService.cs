using Instagram_Backend.Abstracts;
using Instagram_Backend.Database;
using Instagram_Backend.Dtos;
using Instagram_Backend.Dtos.Comments;
using Instagram_Backend.Exceptions;
using Instagram_Backend.Mappers;
using Instagram_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Instagram_Backend.Services;

public class CommentService : ICommentService
{
    private readonly ILogger<CommentService> _logger;
    private readonly ApplicationDbContext _context;
    private readonly INotificationService _notificationService;

    public CommentService(ILogger<CommentService> logger, ApplicationDbContext context , INotificationService notificationService)
    {
        _notificationService = notificationService;
        _logger = logger;
        _context = context;
    }

    public async Task<bool> CreateCommentAsync(CreateCommentDto createCommentDto, Guid PostId, Guid userId)
    {
        var post = await _context.Posts.Where(p => p.Id == PostId).FirstOrDefaultAsync() ;
        if (post == null) {
            throw new NotFoundException($"Error Creating a comment: Post with id = {PostId} is not found");
        }
        
        using var transaction = await _context.Database.BeginTransactionAsync();
        
        try {
            var comment = new Comment
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
                PostId = PostId,
                UserId = userId,
                Content = createCommentDto.Content,
                ParentCommentId = createCommentDto.ParentCommentId
            };
            
            if (createCommentDto.ParentCommentId.HasValue)
            {
                var parentComment = await _context.Comments.FindAsync(createCommentDto.ParentCommentId.Value);
                if (parentComment == null)
                {
                    throw new NotFoundException($"Parent comment with ID = {createCommentDto.ParentCommentId} not found");
                }
                
                parentComment.ReplyCount += 1;
                _context.Comments.Update(parentComment);
            }

            post.CommentCount += 1;


            _context.Posts.Update(post);
            
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            
            if (post != null && post.UserId != userId)
            {
                // Notify post owner about the comment
                await _notificationService.CreateNotificationAsync(
                    NotificationType.Comment, 
                    post.UserId,
                    userId,
                    "commented on your post",
                    PostId,
                    comment.Id); 
            }
            
            // If this is a reply to another comment, notify that comment's owner too
            if (createCommentDto.ParentCommentId.HasValue)
            {
                var parentComment = await _context.Comments
                    .Include(c => c.User)
                    .FirstOrDefaultAsync(c => c.Id == createCommentDto.ParentCommentId.Value);
                    
                if (parentComment != null && parentComment.UserId != userId)
                {
                    await _notificationService.CreateNotificationAsync(
                        NotificationType.Comment,
                        parentComment.UserId,
                        userId,
                        "replied to your comment",
                        PostId,
                        comment.Id);
                }
            }


            return true;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            _logger.LogError(ex, "Failed to create comment");
            throw;
        }
    }

    public async Task<bool> DeleteCommentAsync(Guid commentId, Guid userId)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        
        try
        {
            var comment = await _context.Comments
                .FirstOrDefaultAsync(c => c.Id == commentId);

            if (comment == null)
            {
                _logger.LogWarning("Comment not found: {CommentId}", commentId);
                throw new NotFoundException($"Comment not found with ID = {commentId}");
            }

            if (comment.UserId != userId)
            {
                _logger.LogWarning("User {UserId} attempted to delete a comment they do not own", userId);
                throw new UnauthorizedAccessException("You do not have permission to delete this comment");
            }
            
            if (comment.ParentCommentId.HasValue)
            {
                var parentComment = await _context.Comments
                    .FirstOrDefaultAsync(c => c.Id == comment.ParentCommentId.Value);
                
                if (parentComment != null)
                {
                    parentComment.ReplyCount = Math.Max(0, parentComment.ReplyCount - 1);
                    _context.Comments.Update(parentComment);
                }
            }
            
            var allDescendantIds = await GetAllDescendantIdsAsyncBfs(commentId);

            var totalDescendantCount = allDescendantIds.Count  ; 

            // Delete all descendants explicitly (don't rely on cascade)
            foreach (var descendantId in allDescendantIds.Where(id => id != commentId))
            {
                var descendant = await _context.Comments.FindAsync(descendantId);
                if (descendant != null)
                {
                    _context.Comments.Remove(descendant);
                }
            }


            var post = await _context.Posts.FindAsync(comment.PostId);
            if (post != null)
            {
                post.CommentCount = Math.Max(0, post.CommentCount - totalDescendantCount);
                _context.Posts.Update(post);
            }
            // delete the comment itself
            _context.Comments.Remove(comment);

            
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return true;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            _logger.LogError(ex, "Failed to delete comment");
            throw;
        }
    }

    public async Task<CommentDto> GetCommentByIdAsync(Guid commentId , Guid currentUserId)
    {
        var comment = await _context.Comments
            .Include(c => c.User)
            .FirstOrDefaultAsync(c => c.Id == commentId);

        if (comment == null)
        {
            _logger.LogWarning("Comment not found: {CommentId}", commentId);
            throw new NotFoundException($"Comment not found with ID = {commentId}");
        }

        return MapperDto.MapCommentToDto(comment , currentUserId , _context);
        
    }

    public async Task<PagedResult<CommentDto>> GetCommentRepliesAsync(Guid commentId, int page, int pageSize , Guid currentUserId )
    {

        var commentsQuery =  _context.Comments
            .Include(c => c.User)
            .Where(c => c.ParentCommentId == commentId) ; 

        return await MapperPagedResult.MapPagedResult2(commentsQuery, page, pageSize,
            currentUserId,
            _context,
            (comment, userId, context) => MapperDto.MapCommentToDto(comment , userId , context));
    }

    public async Task<PagedResult<CommentDto>> GetPostCommentsRootAsync(Guid postId, int page, int pageSize, Guid currentUserId )
    {
        var commentsQuery = _context.Comments
            .Include(c => c.User)
            .Where(c => c.PostId == postId && c.ParentCommentId == null);



        return await MapperPagedResult.MapPagedResult2(commentsQuery, page, pageSize,
            currentUserId,
            _context,
            (comment, userId, context) => MapperDto.MapCommentToDto(comment , userId , context));
    }

    public async Task<CommentDto> UpdateCommentAsync(UpdateCommentDto updateCommentDto, Guid commentId, Guid userId)
    {
        var comment = await _context.Comments
            .Include(c => c.User)
            .FirstOrDefaultAsync(c => c.Id == commentId );

        if (comment == null)
        {
            _logger.LogWarning("Comment not found: {CommentId}", commentId);
            throw new NotFoundException($"Comment not found with ID = {commentId}");
        }

        if (comment.UserId != userId)
        {
            _logger.LogWarning("User {UserId} attempted to update a comment they do not own", userId);
            throw new UnauthorizedAccessException("You do not have permission to update this comment");
        }

        comment.Content = updateCommentDto.Content;

        _context.Comments.Update(comment);
        await _context.SaveChangesAsync();

        return MapperDto.MapCommentToDto(comment , userId , _context);
    }


    private async Task<List<Guid>> GetAllDescendantIdsAsyncBfs(Guid commentId)
    {
        var result = new List<Guid>();
        var toProcess = new Queue<Guid>();
        toProcess.Enqueue(commentId);
        result.Add(commentId);
        
        var processed = new HashSet<Guid> { commentId };
        
        while (toProcess.Count > 0)
        {
            var batch = new List<Guid>();
            
            for (int i = 0; i < toProcess.Count; i++)
            {
                batch.Add(toProcess.Dequeue());
            }
            
            var children = await _context.Comments
                .Where(c => c.ParentCommentId.HasValue &&  batch.Contains(c.ParentCommentId.Value))
                .Select(c => c.Id)
                .ToListAsync();
                
            foreach (var child in children)
            {
                if (!processed.Contains(child))
                {
                    result.Add(child);
                    toProcess.Enqueue(child);
                    processed.Add(child);
                }
            }
        }
        
        return result;
    }


}