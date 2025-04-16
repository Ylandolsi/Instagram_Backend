using Instagram_Backend.Dtos;
using Instagram_Backend.Models;

namespace Instagram_Backend.Abstracts;

public interface INotificationService
{
    Task<PagedResult<NotificationDto>> GetUserNotificationsAsync(Guid userId, int page, int pageSize);
    Task <NotificationDto> GetNotificationAsync(Guid notificationId, Guid userId);
    Task<bool> DeleteNotificationAsync(Guid notificationId, Guid userId);
    Task<bool> MarkAsReadAsync(Guid notificationId, Guid userId);
    Task MarkAllAsReadAsync(Guid userId);
    Task CreateNotificationAsync(NotificationType type, Guid userId, Guid actorId, 
        string content, Guid? postId = null, Guid? commentId = null) ; 
    
}