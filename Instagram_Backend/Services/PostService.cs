using Instagram_Backend.Abstracts;
using Instagram_Backend.Database;
using Instagram_Backend.Dtos;
using Instagram_Backend.Dtos.Posts;
using Instagram_Backend.Exceptions;
using Instagram_Backend.Mappers;
using Instagram_Backend.Models;
using Instagram_Backend.Services.ExternalServices;
using Microsoft.EntityFrameworkCore;

namespace Instagram_Backend.Services;

public class PostService : IPostService
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<PostService> _logger;
    private readonly CloudinaryService _cloudinaryService;
    private readonly IImageService _imageService;
    private const int MaxImagesPerPost = 10;
    
    public PostService(ApplicationDbContext context, ILogger<PostService> logger, CloudinaryService cloudinary, IImageService imageService)
    {
        _context = context;
        _logger = logger;
        _cloudinaryService = cloudinary;
        _imageService = imageService;
    }

    public async Task<bool> CreatePostAsync(CreatePostDto postDto, List<IFormFile> images, Guid userId)
    {
        _logger.LogInformation("Creating post for user {UserId} with {ImageCount} images", userId, images.Count);
        
        if (images.Count == 0)
        {
            _logger.LogWarning("Attempt to create post without images by user {UserId}", userId);
            throw new BadRequestException("At least one image is required for a post");
        }
        
        if (images.Count > MaxImagesPerPost)
        {
            _logger.LogWarning("User {UserId} attempted to upload {Count} images, exceeding limit of {MaxImages}", 
                userId, images.Count, MaxImagesPerPost);
            throw new BadRequestException($"Maximum of {MaxImagesPerPost} images allowed per post");
        }
        
        var postId = Guid.NewGuid();
        _logger.LogDebug("Generated post ID: {PostId}", postId);
        
        using var transaction = await _context.Database.BeginTransactionAsync();
        
        try
        {
            var imagesUploaded = await _imageService.UploadImages(images, postId);
            _logger.LogInformation("Successfully uploaded {Count} images for post {PostId}", imagesUploaded.Count, postId);

            var post = new Post
            {
                Id = postId,
                Caption = postDto.Caption,
                UserId = userId,
                Images = imagesUploaded
            };

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            
            await transaction.CommitAsync();
            _logger.LogInformation("Successfully created post {PostId} for user {UserId}", postId, userId);
            return true;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            _logger.LogError(ex, "Error creating post for user {UserId}. Error: {ErrorMessage}", userId, ex.Message);
            throw new InvalidOpException($"Error occurred when creating new post: {ex.Message}");
        }
    }

    public async Task<bool> UpdatePostAsync(UpdatePostDto postDto, Guid postId, Guid userId)
    {
        _logger.LogInformation("Updating post {PostId} for user {UserId}", postId, userId);
        
        var post = await _context.Posts
            .Where(p => p.Id == postId && p.UserId == userId)
            .FirstOrDefaultAsync();
            
        if (post == null)
        {
            _logger.LogWarning("Post {PostId} not found for user {UserId} during update attempt", postId, userId);
            throw new NotFoundException($"Post with id = {postId} is not found");
        }
        
        _logger.LogDebug("Found post {PostId}, updating caption", postId);
        post.Caption = postDto.Caption;
        
        try
        {
            await _context.SaveChangesAsync();
            _logger.LogInformation("Successfully updated post {PostId} for user {UserId}", postId, userId);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating post {PostId} for user {UserId}", postId, userId);
            throw new InvalidOpException($"Failed to update post: {ex.Message}");
        }
    }

    public async Task<bool> DeletePostAsync(Guid postId, Guid userId)
    {
        _logger.LogInformation("Deleting post {PostId} for user {UserId}", postId, userId);
        
        var post = await _context.Posts
            .Where(p => p.Id == postId && p.UserId == userId)
            .Include(p => p.Images)
            .FirstOrDefaultAsync();
            
        if (post == null)
        {
            _logger.LogWarning("Post {PostId} not found for user {UserId} during delete attempt", postId, userId);
            throw new NotFoundException($"Post with id = {postId} is not found");
        }
        
        _logger.LogDebug("Found post {PostId}, proceeding with deletion", postId);
        
        using var transaction = await _context.Database.BeginTransactionAsync();
        
        try
        {
            foreach (var image in post.Images)
            {
                await _imageService.DeleteImageAsync(image.Id);
            }
            
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            
            await transaction.CommitAsync();
            _logger.LogInformation("Successfully deleted post {PostId} for user {UserId}", postId, userId);
            return true;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            _logger.LogError(ex, "Error deleting post {PostId} for user {UserId}: {Error}", 
                postId, userId, ex.Message);
            throw new InvalidOpException($"Failed to delete post: {ex.Message}");
        }
    }

    public async Task<PostDto> GetPostByIdAsync(Guid postId, Guid userId)
    {
        _logger.LogInformation("Retrieving post {PostId} for user {UserId}", postId, userId);
        
        var post = await _context.Posts
            .Where(p => p.Id == postId)
            .Include(p => p.User)
            .Include(p => p.Images)
            .Include(p => p.Comments)
            .Include(p => p.Likes)
            .FirstOrDefaultAsync();
            
        if (post == null)
        {
            _logger.LogWarning("Post {PostId} not found during retrieval", postId);
            throw new NotFoundException($"Post with id = {postId} is not found");
        }
        
        _logger.LogDebug("Found post {PostId} with {ImageCount} images, {CommentCount} comments, {LikeCount} likes", 
            postId, post.Images?.Count ?? 0, post.Comments?.Count ?? 0, post.Likes?.Count ?? 0);
        
        var result = MapperDto.MapPostToDto(post, userId);
        
        _logger.LogInformation("Successfully retrieved post {PostId}", postId);
        return result;
    }


    public async Task<PagedResult<PostDto>> GetPostsByUserIdAsync(Guid userId, int page, int pageSize, Guid currentUserId)
    {
        _logger.LogInformation("Retrieving posts for user {UserId}, page {Page}, size {PageSize}", userId, page, pageSize);
        
        page = Math.Max(1, page);
        pageSize = Math.Clamp(pageSize, 1, 50);
        
        var postsQuery = _context.Posts
            .Where(p => p.UserId == userId)
            .Include(p => p.User)
            .Include(p => p.Images)
            .Include(p => p.Comments)
            .Include(p => p.Likes)
            .OrderByDescending(p => p.CreatedAt);
            
        return await MapperPagedResult.MapPagedResult(
            postsQuery, 
            page, 
            pageSize, 
            currentUserId, 
            (post, userId) => MapperDto.MapPostToDto(post, userId));
    }

    public async Task<PagedResult<PostDto>> GetAllPostsAsync(int page, int pageSize, Guid currentUserId)
    {
        _logger.LogInformation("Retrieving all posts, page {Page}, size {PageSize}", page, pageSize);
        
        page = Math.Max(1, page);
        pageSize = Math.Clamp(pageSize, 1, 50);
        
        var postsQuery = _context.Posts
            .Include(p => p.User)
            .Include(p => p.Images)
            .Include(p => p.Comments)
            .Include(p => p.Likes)
            .OrderByDescending(p => p.CreatedAt);
            
        return await MapperPagedResult.MapPagedResult(
            postsQuery, 
            page, 
            pageSize, 
            currentUserId, 
            (post, userId) => MapperDto.MapPostToDto(post, userId));
    }
    

}




    // public async Task<PagedResult<PostDto>> GetPostsByUserIdAsync(Guid userId, int page, int pageSize, Guid currentUserId)
    // {
    //     _logger.LogInformation("Retrieving posts for user {UserId}, page {Page}, size {PageSize}", userId, page, pageSize);
        
    //     page = Math.Max(1, page);
    //     pageSize = Math.Clamp(pageSize, 1, 50);
        
    //     var totalCount = await _context.Posts
    //         .Where(p => p.UserId == userId)
    //         .CountAsync();
        
    //     var posts = await _context.Posts
    //         .Where(p => p.UserId == userId)
    //         .Include(p => p.User)
    //         .Include(p => p.Images)
    //         .Include(p => p.Comments)
    //         .Include(p => p.Likes)
    //         .OrderByDescending(p => p.CreatedAt) 
    //         .Skip((page - 1) * pageSize)
    //         .Take(pageSize)
    //         .ToListAsync();
            
    //     var postDtos = posts.Select(p => MapperDto.MapPostToDto(p, currentUserId)).ToList();
        
    //     _logger.LogInformation("Retrieved {Count} posts for user {UserId}", posts.Count, userId);
        
    //     return new PagedResult<PostDto>
    //     {
    //         Items = postDtos,
    //         Page = page,
    //         PageSize = pageSize,
    //         TotalCount = totalCount,
    //     };
    // }

    // public async Task<PagedResult<PostDto>> GetAllPostsAsync(int page, int pageSize, Guid currentUserId)
    // {
    //     _logger.LogInformation("Retrieving all posts, page {Page}, size {PageSize}", page, pageSize);
        
    //     page = Math.Max(1, page);
    //     pageSize = Math.Clamp(pageSize, 1, 50);
        
    //     var totalCount = await _context.Posts.CountAsync();
        
    //     var posts = await _context.Posts
    //         .Include(p => p.User)
    //         .Include(p => p.Images)
    //         .Include(p => p.Comments)
    //         .Include(p => p.Likes)
    //         .OrderByDescending(p => p.CreatedAt) 
    //         .Skip((page - 1) * pageSize)
    //         .Take(pageSize)
    //         .ToListAsync();
            
    //     var postDtos = posts.Select(p => MapperDto.MapPostToDto(p, currentUserId))
    //         .ToList();
        
    //     _logger.LogInformation("Retrieved {Count} posts for feed", posts.Count);
        
    //     return new PagedResult<PostDto>
    //     {
    //         Items = postDtos,
    //         Page = page,
    //         PageSize = pageSize,
    //         TotalCount = totalCount,
    //     };
    // }