using JobRepository.Model;
using JobRepository.Repository;
using JobService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobService
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepo _notificationRepo;
        private readonly IApplicationRepo _applicationRepo;
        private readonly IUserRepo _userRepo;

        public NotificationService(INotificationRepo notificationRepo, IApplicationRepo applicationRepo, IUserRepo userRepo)
        {
            _notificationRepo = notificationRepo;
            _applicationRepo = applicationRepo;
            _userRepo = userRepo;
        }

        public void SendNotification(int userId, string type, string content)
        {
            var notification = new Notification
            {
                UserID = userId,
                Type = type,
                Content = content,
                IsRead = false,
                CreatedDate = DateTime.Now
            };

            _notificationRepo.AddNotification(notification);
        }

        public List<Notification> GetUserNotifications(int userId)
        {
            return _notificationRepo.GetUserNotifications(userId);
        }

        public List<Notification> GetUnreadNotifications(int userId)
        {
            return _notificationRepo.GetUnreadNotifications(userId);
        }

        public void MarkAsRead(int notificationId)
        {
            _notificationRepo.MarkAsRead(notificationId);
        }

        public void NotifyApplicationSubmitted(int applicationId)
        {
            var application = _applicationRepo.GetApplicationById(applicationId);
            if (application != null)
            {
                SendNotification(application.UserID, "Application", "Your application has been submitted successfully");
            }
        }

        public void NotifyApplicationApproved(int applicationId)
        {
            var application = _applicationRepo.GetApplicationById(applicationId);
            if (application != null)
            {
                SendNotification(application.UserID, "Application", "Your application has been approved");
            }
        }

        public void NotifyApplicationRejected(int applicationId)
        {
            var application = _applicationRepo.GetApplicationById(applicationId);
            if (application != null)
            {
                SendNotification(application.UserID, "Application", "Your application has been rejected");
            }
        }
    }
}
