using JobRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobService.Service
{
    public interface INotificationService
    {
        void SendNotification(int userId, string type, string content);
        List<Notification> GetUserNotifications(int userId);
        List<Notification> GetUnreadNotifications(int userId);
        void MarkAsRead(int notificationId);
        void NotifyApplicationSubmitted(int applicationId);
        void NotifyApplicationApproved(int applicationId);
        void NotifyApplicationRejected(int applicationId);
    }
}
