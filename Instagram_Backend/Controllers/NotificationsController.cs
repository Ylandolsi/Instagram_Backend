using System.Security.Claims;
using Instagram_Backend.Abstracts;
using Instagram_Backend.Dtos;
using Instagram_Backend.Dtos.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Instagram_Backend.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class NotificationsController : ControllerBase
{
    private readonly INotificationService _notificationService;

    public NotificationsController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetNotification(Guid id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var userGuid))
        {
            return Unauthorized(new ApiResponse<bool>
            {
                Message = "User not found",
                Data = false
            });
        }

        if ( id == Guid.Empty)
        {
            return BadRequest(new ApiResponse<bool>
            {
                Message = "Invalid notification ID",
                Data = false
            });
        }
        var notification = await _notificationService.GetNotificationAsync(id, userGuid);
        if (notification == null)
        {
            return NotFound(new ApiResponse<bool>
            {
                Message = "Notification not found",
                Data = false
            });
        }
        return Ok(new ApiResponse<NotificationDto>
        {
            Message = $"Notification fetched successfully for userId = {userGuid}",
            Data = notification
        });
        
 
    }

    [HttpGet]
    public async Task<IActionResult> GetNotifications([FromQuery] int page = 1,  [FromQuery] int pageSize = 20)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var userGuid))
        {
            return Unauthorized(new ApiResponse<bool>
            {
                Message = "User not found",
                Data = false
            });
        }
        
        var notifications = await _notificationService.GetUserNotificationsAsync(userGuid, page, pageSize);
        return Ok(new ApiResponse<PagedResult<NotificationDto>>
        {
            Message = $"Notifications fetched successfully for userId = {userGuid}",
            Data = notifications
        });
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteNotification(Guid id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var userGuid))
        {
            return Unauthorized(new ApiResponse<bool>
            {
                Message = "User not found",
                Data = false
            });
        }
        
        var result = await _notificationService.DeleteNotificationAsync(id, userGuid);
        
        if (!result)
        {
            return NotFound(new ApiResponse<bool>
            {
                Message = "Notification not found or doesn't belong to you",
                Data = false
            });
        }
        
        return Ok(new ApiResponse<bool>
        {
            Message = "Notification deleted successfully",
            Data = true
        });
    }

    [HttpPost("{id:guid}/read")]
    public async Task<IActionResult> MarkAsRead(Guid id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var userGuid))
        {
            return Unauthorized(new ApiResponse<bool>
            {
                Message = "User not found",
                Data = false
            });
        }
        
        var result = await _notificationService.MarkAsReadAsync(id, userGuid);
        
        if (!result)
        {
            return NotFound(new ApiResponse<bool>
            {
                Message = "Notification not found or doesn't belong to you",
                Data = false
            });
        }
        
        return Ok(new ApiResponse<bool>
        {
            Message = "Notification marked as read successfully",
            Data = true
        });
    }

    [HttpPost("read-all")]
    public async Task<IActionResult> MarkAllAsRead()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var userGuid))
        {
            return Unauthorized(new ApiResponse<bool>
            {
                Message = "User not found",
                Data = false
            });
        }
        
        await _notificationService.MarkAllAsReadAsync(userGuid);
        
        return Ok(new ApiResponse<bool>
        {
            Message = "All notifications marked as read successfully",
            Data = true
        });
    }
}