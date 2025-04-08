using Instagram_Backend.Abstracts;
using Instagram_Backend.Database;
using Instagram_Backend.Dtos;
using Instagram_Backend.Dtos.Posts;
using Instagram_Backend.Exceptions;
using Instagram_Backend.Mappers;
using Instagram_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Instagram_Backend.Services;

public class LikeService : ILikeService
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<LikeService> _logger;
    private readonly INotificationService _notificationService;

    public LikeService(ApplicationDbContext context, ILogger<LikeService> logger  , INotificationService notificationService)
    {
        _context = context;
        _logger = logger;
        _notificationService = notificationService;
    }

    public async Task<bool> ToggleLikePostAsync(Guid postId, Guid userId)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        
        try
        {
            var post = await _context.Posts.FindAsync(postId);
            if (post == null)
                throw new NotFoundException($"Post not found");
                
            var existingLike = await _context.Likes
                .FirstOrDefaultAsync(l => l.PostId == postId && l.UserId == userId);
                
            if (existingLike != null)
            {
                // Unlike
                _context.Likes.Remove(existingLike);
                post.LikeCount = Math.Max(0, post.LikeCount - 1);
            }
            else
            {
                // Like
                var like = new Like
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    PostId = postId,
                    Type = LikeType.Post,
                    CreatedAt = DateTime.UtcNow
                };
                
                _context.Likes.Add(like);
                post.LikeCount += 1;
            }
            




            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            if ( post != null && existingLike == null && post.UserId != userId)
            {
                await _notificationService.CreateNotificationAsync(
                NotificationType.Like, 
                post.UserId, // receiver
                userId,      // sender
                "liked your post",
                postId);
                
            }
            
            return existingLike == null; //  true if liked, false if unliked
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            _logger.LogError(ex, "Error toggling post like");
            throw;
        }
    }

    public async Task<bool> ToggleLikeCommentAsync(Guid commentId, Guid userId)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        
        try
        {
            var comment = await _context.Comments.FindAsync(commentId);
            if (comment == null)
                throw new NotFoundException($"Comment not found");
                
            var existingLike = await _context.Likes
                .FirstOrDefaultAsync(l => l.CommentId == commentId && l.UserId == userId);
                
            if (existingLike != null)
            {
                // Unlike
                _context.Likes.Remove(existingLike);
                comment.LikeCount = Math.Max(0, comment.LikeCount - 1);
            }
            else
            {
                // Like
                var like = new Like
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    CommentId = commentId,
                    Type = LikeType.Comment,
                    CreatedAt = DateTime.UtcNow
                };
                
                _context.Likes.Add(like);
                comment.LikeCount += 1;
            }
            

            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            if ( comment != null && existingLike == null && comment.UserId != userId)
            {
                await _notificationService.CreateNotificationAsync(
                NotificationType.Like, 
                comment.UserId, // receiver
                userId,      // sender
                "liked your comment",
                null , commentId);
                
            }



            return existingLike == null; // true if liked, false if unliked
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            _logger.LogError(ex, "Error toggling comment like");
            throw;
        }
    }

    public async Task<bool> IsPostLikedByUserAsync(Guid postId, Guid userId)
    {
        _logger.LogDebug("Checking if post {PostId} is liked by user {UserId}", postId, userId);
        
        try
        {
            var isLiked = await _context.Likes
                .AnyAsync(l => l.PostId == postId && l.UserId == userId && l.Type == LikeType.Post);
                
            _logger.LogDebug("Post {PostId} is{IsLiked} liked by user {UserId}", 
                postId, isLiked ? "" : " not", userId);
                
            return isLiked;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error checking if post {PostId} is liked by user {UserId}", postId, userId);
            throw new InvalidOpException($"Failed to check like status: {ex.Message}");
        }
    }

    public async Task<bool> IsCommentLikedByUserAsync(Guid commentId, Guid userId)
    {
        _logger.LogDebug("Checking if comment {CommentId} is liked by user {UserId}", commentId, userId);
        
        try
        {
            var isLiked = await _context.Likes
                .AnyAsync(l => l.CommentId == commentId && l.UserId == userId && l.Type == LikeType.Comment);
                
            _logger.LogDebug("Comment {CommentId} is{IsLiked} liked by user {UserId}", 
                commentId, isLiked ? "" : " not", userId);
                
            return isLiked;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error checking if comment {CommentId} is liked by user {UserId}", commentId, userId);
            throw new InvalidOpException($"Failed to check like status: {ex.Message}");
        }
    }

    public async Task<PagedResult<PostDto>> GetLikedPostsByUserAsync(Guid userId, int page, int pageSize)
    {
        if (userId == Guid.Empty)
            throw new BadRequestException("User ID cannot be empty");

        page = Math.Max(1, page);
        pageSize = Math.Clamp(pageSize, 1, 50);
        
        _logger.LogInformation("Retrieving liked posts for user {UserId}, page {Page}, size {PageSize}", 
            userId, page, pageSize);
            
        try
        {
            // Get the posts that the user liked
            var likedPostsQuery = _context.Likes
                .Where(l => l.UserId == userId && l.Type == LikeType.Post)
                .Include(l => l.Post)
                .ThenInclude(p => p.User)
                .Include(l => l.Post.Images)
                .OrderByDescending(l => l.CreatedAt)
                .Select(l => l.Post);
                
            return await MapperPagedResult.MapPagedResult(
                likedPostsQuery, 
                page, 
                pageSize, 
                (post) => {
                    var dto = MapperDto.MapPostToDto(post, userId , null );
                    dto.IsLikedByCurrentUser = true; // Always true bcz these are liked posts
                    return dto;
                });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving liked posts for user {UserId}", userId);
            throw new InvalidOpException($"Failed to retrieve liked posts: {ex.Message}");
        }
    }

    public async Task<PagedResult<UserDto>> GetUsersWhoLikedPostAsync(Guid postId, int page, int pageSize)
    {
        _logger.LogInformation("Retrieving users who liked post {PostId}, page {Page}, size {PageSize}", 
            postId, page, pageSize);
            
        page = Math.Max(1, page);
        pageSize = Math.Clamp(pageSize, 1, 50);
        
        try
        {
            var post = await _context.Posts.FindAsync(postId);
            if (post == null)
            {
                _logger.LogWarning("Post {PostId} not found when retrieving likes", postId);
                throw new NotFoundException($"Post with ID = {postId} not found");
            }
            
            var usersQuery = _context.Likes
                .Where(l => l.PostId == postId && l.Type == LikeType.Post)
                .Include(l => l.User)
                .OrderByDescending(l => l.CreatedAt)
                .Select(l => l.User);
                
            return await MapperPagedResult.MapPagedResult(
                usersQuery, 
                page, 
                pageSize, 
                user => MapperDto.MapUserToDto(user));
        }
        catch (NotFoundException)
        {
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving users who liked post {PostId}", postId);
            throw new InvalidOpException($"Failed to retrieve users: {ex.Message}");
        }
    }
}

