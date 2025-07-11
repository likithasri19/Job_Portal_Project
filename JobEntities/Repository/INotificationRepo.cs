using JobRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobRepository.Repository
{
    public interface INotificationRepo
    {
        void AddNotification(Notification notification);
        List<Notification> GetAllNotifications();
        List<Notification> GetUserNotifications(int userId);
        List<Notification> GetUnreadNotifications(int userId);
        void MarkAsRead(int notificationId);
        void DeleteNotification(int id);
    }

}
