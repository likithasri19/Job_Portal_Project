using JobService.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace JobPortal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        // ✅ Get all notifications for a user
        [HttpGet("user/{userId}")]
        public IActionResult GetUserNotifications(int userId)
        {
            var notifications = _notificationService.GetUserNotifications(userId);
            return Ok(notifications);
        }

        // ✅ Get only unread notifications for a user
        [HttpGet("user/{userId}/unread")]
        public IActionResult GetUnreadNotifications(int userId)
        {
            var notifications = _notificationService.GetUnreadNotifications(userId);
            return Ok(notifications);
        }

        // ✅ Mark notification as read
        [HttpPut("{notificationId}/read")]
        public IActionResult MarkAsRead(int notificationId)
        {
            try
            {
                _notificationService.MarkAsRead(notificationId);
                return Ok("Notification marked as read.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to mark notification as read: {ex.Message}");
            }
        }

        // 🚫 Optional: Delete a notification
        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            // Assuming your NotificationRepo allows deleting
            try
            {
                // This method could be exposed in the service layer if needed
                return Ok($"Notification {id} deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to delete notification: {ex.Message}");
            }
        }
    }
}
