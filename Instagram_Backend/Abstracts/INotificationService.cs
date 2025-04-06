namespace Instagram_Backend.Abstracts;

public interface INotificationService
{
    Task<List<NotificationDto>> GetUserNotificationsAsync(Guid userId, int page, int pageSize);
    Task<bool> DeleteNotificationAsync(Guid notificationId, Guid userId);
    Task<bool> MarkAsReadAsync(Guid notificationId, Guid userId);
    Task MarkAllAsReadAsync(Guid userId);
    
    // Methods that will emit events (for real-time later)
    // Task CreateNotificationAsync(NotificationType type, Guid userId, Guid actorId, string message, Guid? postId = null, Guid? commentId = null);
    // event EventHandler<NotificationEventArgs> OnNotificationCreated;
}