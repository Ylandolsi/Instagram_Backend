

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

    public CommentService(ILogger<CommentService> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<bool> CreateCommentAsync(CreateCommentDto createCommentDto, Guid PostId, Guid userId)
    {
        var comment = new Comment
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            PostId = PostId,
            UserId = userId,
            Content = createCommentDto.Content,
            ParentCommentId = createCommentDto.ParentCommentId
        };

        await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();

        return true ; 
    }


    public async Task<bool> DeleteCommentAsync(Guid commentId, Guid userId)
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

        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<CommentDto> GetCommentByIdAsync(Guid commentId)
    {
        var comment = await _context.Comments
            .Include(c => c.User)
            .FirstOrDefaultAsync(c => c.Id == commentId);

        if (comment == null)
        {
            _logger.LogWarning("Comment not found: {CommentId}", commentId);
            throw new NotFoundException($"Comment not found with ID = {commentId}");
        }

        return MapperDto.MapCommentToDto(comment , Guid.Empty);
        
    }

    public async Task<PagedResult<CommentDto>> GetCommentRepliesAsync(Guid commentId, int page, int pageSize)
    {

        var commentsQuery =  _context.Comments
            .Where(c => c.ParentCommentId == commentId) ; 

        return await MapperPagedResult.MapPagedResult(commentsQuery , page ,pageSize , 
            commentsQuery => MapperDto.MapCommentToDto(commentsQuery , Guid.Empty));
        
    }

    public async Task<PagedResult<CommentDto>> GetPostCommentsAsync(Guid postId, int page, int pageSize, bool rootCommentsOnly = true)
    {
        var commentsQuery = _context.Comments
            .Where(c => c.PostId == postId);

        if (rootCommentsOnly)
        {
            commentsQuery = commentsQuery.Where(c => c.ParentCommentId == null);
        }

        return await MapperPagedResult.MapPagedResult(commentsQuery, page, pageSize,
            commentsQuery => MapperDto.MapCommentToDto(commentsQuery , Guid.Empty));
    }

    public async Task<CommentDto> UpdateCommentAsync(UpdateCommentDto updateCommentDto, Guid commentId, Guid userId)
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
            _logger.LogWarning("User {UserId} attempted to update a comment they do not own", userId);
            throw new UnauthorizedAccessException("You do not have permission to update this comment");
        }

        comment.Content = updateCommentDto.Content;

        _context.Comments.Update(comment);
        await _context.SaveChangesAsync();

        return MapperDto.MapCommentToDto(comment , Guid.Empty);
    }


}