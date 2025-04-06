// using System.Security.Claims;
// using Instagram_Backend.Abstracts;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;

// namespace Instagram_Backend.Controllers;

// [Authorize]
// [ApiController]
// [Route("api/[controller]")]
// public class NotificationsController : ControllerBase
// {
//     private readonly INotificationService _notificationService;

//     public NotificationsController(INotificationService notificationService)
//     {
//         _notificationService = notificationService;
//     }

//     [HttpGet]
//     public async Task<IActionResult> GetNotifications([FromQuery] int page = 1, [FromQuery] int pageSize = 20)
//     {
//         var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
//         if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var userGuid))
//         {
//             return Unauthorized();
//         }
        
//         var notifications = await _notificationService.GetUserNotificationsAsync(userGuid, page, pageSize);
//         return Ok(notifications);
//     }

//     [HttpDelete("{id:guid}")]
//     public async Task<IActionResult> DeleteNotification(Guid id)
//     {
//         var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
//         if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var userGuid))
//         {
//             return Unauthorized();
//         }
        
//         // Add ownership check to prevent users from deleting others' notifications
//         var result = await _notificationService.DeleteNotificationAsync(id, userGuid);
        
//         if (!result)
//         {
//             return NotFound(new{ message = "Notification not found or doesn't belong to you" });
//         }
        
//         return Ok(new { message = "Notification deleted successfully" });
//     }

//     [HttpPatch("{id:guid}/read")]
//     public async Task<IActionResult> MarkAsRead(Guid id)
//     {
//         var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
//         if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var userGuid))
//         {
//             return Unauthorized();
//         }
        
//         var result = await _notificationService.MarkAsReadAsync(id, userGuid);
        
//         if (!result)
//         {
//             return NotFound(new {message= "Notification not found or doesn't belong to you"});
//         }
        
//         return NoContent();
//     }

//     [HttpPatch("read-all")]
//     public async Task<IActionResult> MarkAllAsRead()
//     {
//         var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
//         if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var userGuid))
//         {
//             return Unauthorized(new { message = "User not found" });
//         }
        
//         await _notificationService.MarkAllAsReadAsync(userGuid);
//         return Ok(new { message = "All notifications marked as read" });
//     }
// }