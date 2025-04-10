using Instagram_Backend.Abstracts;
using Instagram_Backend.Database;
using Instagram_Backend.Dtos;
using Instagram_Backend.Exceptions;
using Instagram_Backend.Mappers;
using Instagram_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Instagram_Backend.Services;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<UserService> _logger;
    private readonly INotificationService _notificationService;

    public UserService(ApplicationDbContext context, ILogger<UserService> logger , INotificationService notificationService)
    {
        _context = context;
        _logger = logger;
        _notificationService = notificationService;
    }



    public async Task<bool> FollowUser(Guid userId, Guid toFollowId)
    {
        _logger.LogInformation("User {UserId} attempting to follow {ToFollowId}", userId, toFollowId);

        // Validate inputs
        if (userId == toFollowId)
        {
            _logger.LogWarning("User {UserId} attempted to follow themselves", userId);
            throw new BadRequestException("Users cannot follow themselves");
        }

        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == userId);

        if (user == null)
        {
            _logger.LogWarning("User not found: {UserId}", userId);
            throw new NotFoundException($"User not found with ID = {userId}");
        }

        var toFollowUser = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == toFollowId);

        if (toFollowUser == null)
        {
            _logger.LogWarning("User to follow not found: {ToFollowId}", toFollowId);
            throw new NotFoundException($"User not found with ID = {toFollowId}");
        }

        var FollowOp = await _context.UserFollowers.Where(f  => f.FollowerId == userId && f.FollowingId == toFollowId)
                        .FirstOrDefaultAsync();

        if (FollowOp != null)
        {
            _logger.LogWarning("User {UserId} is already following {ToFollowId}", userId, toFollowId);
            throw new BadRequestException($"Already following user with ID = {toFollowId}");
        }

        using var transaction = await _context.Database.BeginTransactionAsync();
        
        try
        {
            _context.UserFollowers.Add(new UserFollower
            {
                FollowerId = userId,
                FollowingId = toFollowId
            });

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            _logger.LogInformation("User {UserId} successfully followed {ToFollowId}", userId, toFollowId);
            
            await _notificationService.CreateNotificationAsync(
                    Models.NotificationType.Follow,
                    toFollowId,
                    userId,
                    "started following you");
            return true;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            _logger.LogError(ex, "Error when user {UserId} attempted to follow {ToFollowId}", userId, toFollowId);
            throw new InvalidOpException($"Failed to follow user: {ex.Message}");
        }
    }

    public async Task<bool> UnfollowUser(Guid userId, Guid toUnfollowId)
    {
        _logger.LogInformation("User {UserId} attempting to unfollow {ToUnfollowId}", userId, toUnfollowId);

        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == userId);

        if (user == null)
        {
            _logger.LogWarning("User not found: {UserId}", userId);
            throw new NotFoundException($"User not found with ID = {userId}");
        }

        var toUnfollowUser = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == toUnfollowId);

        if (toUnfollowUser == null)
        {
            _logger.LogWarning("User to unfollow not found: {ToUnfollowId}", toUnfollowId);
            throw new NotFoundException($"User not found with ID = {toUnfollowId}");
        }

        var FollowOp = await _context.UserFollowers.Where(f  => f.FollowerId == userId && f.FollowingId == toUnfollowId)
                        .FirstOrDefaultAsync();

        if (FollowOp == null)
        {
            _logger.LogWarning("User {UserId} is not following {ToUnfollowId}", userId, toUnfollowId);
            throw new BadRequestException($"Not following user with ID = {toUnfollowId}");
        }

        using var transaction = await _context.Database.BeginTransactionAsync();
        
        try
        {
            _context.UserFollowers.Remove(FollowOp);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            _logger.LogInformation("User {UserId} successfully unfollowed {ToUnfollowId}", userId, toUnfollowId);
            return true;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            _logger.LogError(ex, "Error when user {UserId} attempted to unfollow {ToUnfollowId}", userId, toUnfollowId);
            throw new InvalidOpException($"Failed to unfollow user: {ex.Message}");
        }
    }

    public async Task<PagedResult<UserDto>> GetMyFollowers(int page, int pageSize, Guid userId)
    {
        _logger.LogInformation("Fetching followers for user {UserId} with page {Page} and pageSize {PageSize}", userId, page, pageSize);

        page = Math.Max(1, page);
        pageSize = Math.Clamp(pageSize, 1, 50);

        var followersQuery = _context.UserFollowers.Where(f => f.FollowingId == userId)
            .Include(f => f.Follower)
            .Select(f => f.Follower)
            .OrderBy(u => u.UserName);

        if ( followersQuery == null)
        {
            _logger.LogWarning("No followers found for user {UserId}", userId);
            return new PagedResult<UserDto>
            {
                Items = new List<UserDto>(),
                Page = 0,
                PageSize = pageSize,
                TotalCount = 0,
            };
        }
            
        return await MapperPagedResult.MapPagedResult(
            followersQuery, 
            page, 
            pageSize, 
            user => MapperDto.MapUserToDto(user));
    }

    public async Task<PagedResult<UserDto>> GetMyFollowing(int page, int pageSize, Guid userId)
    {
        _logger.LogInformation("Fetching followings for user {UserId} with page {Page} and pageSize {PageSize}", userId, page, pageSize);

        page = Math.Max(1, page);
        pageSize = Math.Clamp(pageSize, 1, 50);



        var followingQuery = _context.UserFollowers.Where(f => f.FollowerId == userId)
            .Include(f => f.Following)
            .Select(f => f.Following)
            .OrderBy(u => u.UserName);
        
        if (followingQuery == null)
        {
            _logger.LogWarning("No followings found for user {UserId}", userId);
            return new PagedResult<UserDto>
            {
                Items = new List<UserDto>(),
                Page = 0,
                PageSize = pageSize,
                TotalCount = 0,
            };
        }
            
        return await MapperPagedResult.MapPagedResult(
            followingQuery, 
            page, 
            pageSize, 
            user => MapperDto.MapUserToDto(user));
    }

    public async Task<PagedResult<UserDto>> SearchUsersAsync(string query, int page, int pageSize, Guid currentUserId)
    {
        _logger.LogInformation("Searching users with query '{Query}', page {Page}, pageSize {PageSize}", 
            query, page, pageSize);

        page = Math.Max(1, page);
        pageSize = Math.Clamp(pageSize, 1, 50);
        
        if (string.IsNullOrWhiteSpace(query))
        {
            return new PagedResult<UserDto>
            {
                Items = new List<UserDto>(),
                Page = 0,
                PageSize = pageSize,
                TotalCount = 0,
            };
        }
        
        query = query.Trim().ToLower();

        var followingIds = await _context.UserFollowers
                                    .Where(uf => uf.FollowerId == currentUserId)
                                    .Select(uf => uf.FollowingId)
                                    .ToHashSetAsync() 
                                    ?? new HashSet<Guid>();
        
        var usersQuery = _context.Users
            .Where(u => u.Id != currentUserId) 
            .Where(u => 
                (u.UserName != null && u.UserName.ToLower().Contains(query)) || 
                (u.FirstName != null && u.FirstName.ToLower().Contains(query)) || 
                (u.LastName != null && u.LastName.ToLower().Contains(query)))
            .OrderBy(u => u.UserName);
        
        var result = await MapperPagedResult.MapPagedResult2(
            usersQuery, 
            page, 
            pageSize,
            currentUserId,
            _context,
            (user, userId, context) => {
                var dto = MapperDto.MapUserToDto(user);
                dto.IsFollowedByCurrentUser = followingIds.Contains(user.Id);
                return dto;
            });
        
        return result;
    }



}