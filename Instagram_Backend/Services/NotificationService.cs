using Instagram_Backend.Abstracts;
using Instagram_Backend.Database;
using Instagram_Backend.Dtos;
using Instagram_Backend.Dtos.Notifications;
using Instagram_Backend.Exceptions;
using Instagram_Backend.Hubs;
using Instagram_Backend.Mappers;
using Instagram_Backend.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Instagram_Backend.Services;

public class NotificationService : INotificationService
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<NotificationService> _logger;
    private readonly IHubContext<NotificationHub> _hubContext;

    public NotificationService(ApplicationDbContext context, ILogger<NotificationService> logger , IHubContext<NotificationHub> hubContext)
    {
        _context = context;
        _logger = logger;
        _hubContext = hubContext;
    }
    public async Task<NotificationDto> GetNotificationAsync(Guid notificationId, Guid userId)
    {
        var notification = await _context.Notifications
            .Include(n => n.Actor)
            .Include(n => n.Post)
            .Include(n => n.Comment)
                .ThenInclude(c => c != null ? c.User : null)
            .FirstOrDefaultAsync(n => n.Id == notificationId );

        if (notification == null)
        {
            throw new NotFoundException ("Notification not found.");
        }
        if ( notification.UserId != userId)
        {
            throw new UnauthorizedAccessException("You are not authorized to access this notification.");
        }

        return MapperDto.MapNotificationToDto(notification);
    }

    public async Task<PagedResult<NotificationDto>> GetUserNotificationsAsync(Guid userId, int page, int pageSize)
    {
        _logger.LogInformation("Fetching notifications for user {UserId} with page {Page} and pageSize {PageSize}", 
            userId, page, pageSize);

        // Ensure valid paging parameters
        page = Math.Max(1, page);
        pageSize = Math.Clamp(pageSize, 1, 50);

        var notificationsQuery = _context.Notifications
            .Where(n => n.UserId == userId)
            .OrderByDescending(n => n.CreatedAt)
            .Include(n => n.Actor)
            .Include(n => n.Post)
            .Include(n => n.Comment)
                .ThenInclude(c => c != null ? c.User : null);
                
        return await MapperPagedResult.MapPagedResult(
            notificationsQuery, 
            page, 
            pageSize, 
            notification => MapperDto.MapNotificationToDto(notification));
    }

    public async Task<bool> DeleteNotificationAsync(Guid notificationId, Guid userId)
    {
        var notification = await _context.Notifications
            .FirstOrDefaultAsync(n => n.Id == notificationId && n.UserId == userId);

        if (notification == null)
        {
            return false;
        }

        _context.Notifications.Remove(notification);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> MarkAsReadAsync(Guid notificationId, Guid userId)
    {
        var notification = await _context.Notifications
            .FirstOrDefaultAsync(n => n.Id == notificationId && n.UserId == userId);

        if (notification == null)
        {
            return false;
        }

        notification.IsRead = true;
        _context.Notifications.Update(notification);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task MarkAllAsReadAsync(Guid userId)
    {
        var notifications = await _context.Notifications
            .Where(n => n.UserId == userId && !n.IsRead)
            .ToListAsync();

        foreach (var notification in notifications)
        {
            notification.IsRead = true;
        }

        await _context.SaveChangesAsync();
    }

    public async Task CreateNotificationAsync(NotificationType type, Guid userId, Guid actorId, 
        string content, Guid? postId = null, Guid? commentId = null)
    {
        if (userId == actorId)
        {
            return;
        }

        var notification = new Notification
        {
            Id = Guid.NewGuid(),
            Type = type,
            UserId = userId,
            ActorId = actorId,
            Content = content,
            PostId = postId,
            CommentId = commentId,
            CreatedAt = DateTime.UtcNow,
            IsRead = false,
        };

        _context.Notifications.Add(notification);
        await _context.SaveChangesAsync();

        notification = await _context.Notifications
            .Include(n => n.Actor)
            .Include(n => n.Post)
                 .ThenInclude(p => p != null ? p.User : null)
            .Include(n => n.Comment)
                .ThenInclude(c => c != null ? c.User : null)
            .FirstOrDefaultAsync(n => n.Id == notification.Id);
        
        try 
        {
            if (_hubContext != null) 
            {
                await _hubContext.Clients.Group(userId.ToString())
                    .SendAsync("ReceiveNotification", MapperDto.MapNotificationToDto(notification));
                    
                _logger.LogInformation("Real-time notification sent successfully to user {UserId}", userId);
            }
        }
        catch (Exception ex) 
        {
            _logger.LogWarning(ex, "Failed to send real-time notification to user {UserId}. " +
                "Notification was saved to database.", userId);
        }

        _logger.LogInformation("Notification created: {NotificationId} for user {UserId}", 
            notification.Id, userId);
    }
}