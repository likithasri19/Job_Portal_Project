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
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepo _applicationRepo;
        private readonly INotificationService _notificationService;

        public ApplicationService(IApplicationRepo applicationRepo, INotificationService notificationService)
        {
            _applicationRepo = applicationRepo;
            _notificationService = notificationService;
        }

        public void SubmitApplication(int userId, int jobId, string coverLetter)
        {
            if (_applicationRepo.HasUserApplied(userId, jobId))
            {
                throw new InvalidOperationException("User has already applied for this job");
            }

            var application = new Application
            {
                UserID = userId,
                JobID = jobId,
                CoverLetter = coverLetter,
                ApplicationDate = DateTime.Now,
                Status = false
            };

            _applicationRepo.AddApplication(application);
            _notificationService.NotifyApplicationSubmitted(application.ApplicationID);
        }

        public List<Application> GetAllApplications()
        {
            return _applicationRepo.GetAllApplications();
        }

        public Application GetApplicationById(int id)
        {
            return _applicationRepo.GetApplicationById(id);
        }

        public List<Application> GetUserApplications(int userId)
        {
            return _applicationRepo.GetApplicationsByUser(userId);
        }

        public List<Application> GetJobApplications(int jobId)
        {
            return _applicationRepo.GetApplicationsByJob(jobId);
        }

        public void UpdateApplicationStatus(int applicationId, bool status)
        {
            var application = _applicationRepo.GetApplicationById(applicationId);
            if (application != null)
            {
                application.Status = status;
                _applicationRepo.UpdateApplication(application);
            }
        }

        public bool HasUserApplied(int userId, int jobId)
        {
            return _applicationRepo.HasUserApplied(userId, jobId);
        }
    }


}
