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

    public LikeService(ApplicationDbContext context, ILogger<LikeService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<bool> ToggleLikePostAsync(Guid postId, Guid userId)
    {
        _logger.LogInformation("Toggling like for post {PostId} by user {UserId}", postId, userId);

        try
        {
            var post = await _context.Posts.FindAsync(postId);
            if (post == null)
            {
                _logger.LogWarning("Post {PostId} not found when toggling like", postId);
                throw new NotFoundException($"Post with ID = {postId} not found");
            }

            var like = await _context.Likes
                .FirstOrDefaultAsync(l => l.PostId == postId && l.UserId == userId && l.Type == LikeType.Post);

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                if (like != null)
                {
                    // Unlike
                    _context.Likes.Remove(like);
                    _logger.LogDebug("User {UserId} removing like from post {PostId}", userId, postId);
                }
                else
                {
                    // Like
                    _context.Likes.Add(new Like
                    {
                        Id = Guid.NewGuid(),
                        PostId = postId,
                        UserId = userId,
                        Type = LikeType.Post,
                        CreatedAt = DateTime.UtcNow
                    });
                    _logger.LogDebug("User {UserId} adding like to post {PostId}", userId, postId);
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                
                _logger.LogInformation("Successfully toggled like for post {PostId} by user {UserId}", postId, userId);
                return like == null; // true if it was liked, false if unliked
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "Error toggling like for post {PostId} by user {UserId}", postId, userId);
                throw new InvalidOpException($"Failed to toggle like: {ex.Message}");
            }
        }
        catch (NotFoundException)
        {
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error toggling like for post {PostId} by user {UserId}", postId, userId);
            throw new InvalidOpException($"An error occurred: {ex.Message}");
        }
    }

    public async Task<bool> ToggleLikeCommentAsync(Guid commentId, Guid userId)
    {
        _logger.LogInformation("Toggling like for comment {CommentId} by user {UserId}", commentId, userId);

        try
        {
            var comment = await _context.Comments.FindAsync(commentId);
            if (comment == null)
            {
                _logger.LogWarning("Comment {CommentId} not found when toggling like", commentId);
                throw new NotFoundException($"Comment with ID = {commentId} not found");
            }

            var like = await _context.Likes
                .FirstOrDefaultAsync(l => l.CommentId == commentId && l.UserId == userId && l.Type == LikeType.Comment);

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                if (like != null)
                {
                    // Unlike
                    _context.Likes.Remove(like);
                    _logger.LogDebug("User {UserId} removing like from comment {CommentId}", userId, commentId);
                }
                else
                {
                    // Like
                    _context.Likes.Add(new Like
                    {
                        Id = Guid.NewGuid(),
                        CommentId = commentId,
                        UserId = userId,
                        Type = LikeType.Comment,
                        CreatedAt = DateTime.UtcNow
                    });
                    _logger.LogDebug("User {UserId} adding like to comment {CommentId}", userId, commentId);
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                
                _logger.LogInformation("Successfully toggled like for comment {CommentId} by user {UserId}", commentId, userId);
                return like == null; //  true if it was liked, false if unliked
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "Error toggling like for comment {CommentId} by user {UserId}", commentId, userId);
                throw new InvalidOpException($"Failed to toggle like: {ex.Message}");
            }
        }
        catch (NotFoundException)
        {
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error toggling like for comment {CommentId} by user {UserId}", commentId, userId);
            throw new InvalidOpException($"An error occurred: {ex.Message}");
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
                .Include(l => l.Post.Comments)
                .Include(l => l.Post.Likes)
                .OrderByDescending(l => l.CreatedAt)
                .Select(l => l.Post);
                
            return await MapperPagedResult.MapPagedResult(
                likedPostsQuery, 
                page, 
                pageSize, 
                (post) => {
                    var dto = MapperDto.MapPostToDto(post, userId);
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

