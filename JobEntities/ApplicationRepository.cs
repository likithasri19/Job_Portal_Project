using JobRepository.Model;
using JobRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobRepository
{
    public class ApplicationRepository : IApplicationRepo
    {
        private static List<Application> applications = new List<Application>();

        public void AddApplication(Application application)
        {
            applications.Add(application);
        }

        public List<Application> GetAllApplications() => applications;

        public Application GetApplicationById(int id)
        {
            return applications.FirstOrDefault(a => a.ApplicationID == id);
        }

        public List<Application> GetApplicationsByJob(int jobId)
        {
            return applications.Where(a => a.JobID == jobId).ToList();
        }

        public List<Application> GetApplicationsByUser(int userId)
        {
            return applications.Where(a => a.UserID == userId).ToList();
        }

        public void UpdateApplication(Application application)
        {
            var existingApp = GetApplicationById(application.ApplicationID);
            if (existingApp != null)
            {
                existingApp.Status = application.Status;
                existingApp.CoverLetter = application.CoverLetter;
            }
        }

        public bool HasUserApplied(int userId, int jobId)
        {
            return applications.Any(a => a.UserID == userId && a.JobID == jobId);
        }
    }
}
