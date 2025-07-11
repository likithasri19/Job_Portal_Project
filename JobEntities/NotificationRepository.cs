using JobRepository.Model;
using JobRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobRepository
{
    public class NotificationRepository : INotificationRepo
    {
        private static List<Notification> notifications = new List<Notification>();

        public void AddNotification(Notification notification)
        {
            notifications.Add(notification);
        }

        public List<Notification> GetAllNotifications() => notifications;

        public List<Notification> GetUserNotifications(int userId)
        {
            return notifications.Where(n => n.UserID == userId).ToList();
        }

        public List<Notification> GetUnreadNotifications(int userId)
        {
            return notifications.Where(n => n.UserID == userId && n.IsRead == false).ToList();
        }

        public void MarkAsRead(int notificationId)
        {
            var notification = notifications.FirstOrDefault(n => n.NotificationID == notificationId);
            if (notification != null)
            {
                notification.IsRead = true;
            }
        }

        public void DeleteNotification(int id)
        {
            var notification = notifications.FirstOrDefault(n => n.NotificationID == id);
            if (notification != null)
            {
                notifications.Remove(notification);
            }
        }
    }
}

