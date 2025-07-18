using JobRepository.Model;
using JobRepository.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace JobRepository
{
    public class ApplicationRepository : IApplicationRepo
    {
        private readonly JobPortalContext _context;

        public ApplicationRepository(JobPortalContext context)
        {
            _context = context;
        }

        public void AddApplication(Application application)
        {
            _context.Applications.Add(application);
            _context.SaveChanges();
        }

        public List<Application> GetAllApplications()
        {
            return _context.Applications.ToList();
        }

        public Application GetApplicationById(int id)
        {
            return _context.Applications.FirstOrDefault(a => a.ApplicationID == id);
        }

        public List<Application> GetApplicationsByJob(int jobId)
        {
            return _context.Applications.Where(a => a.JobID == jobId).ToList();
        }

        public List<Application> GetApplicationsByUser(int userId)
        {
            return _context.Applications.Where(a => a.UserID == userId).ToList();
        }

        public void UpdateApplication(Application application)
        {
            _context.Applications.Update(application);
            _context.SaveChanges();
        }

        public bool HasUserApplied(int userId, int jobId)
        {
            return _context.Applications.Any(a => a.UserID == userId && a.JobID == jobId);
        }
    }
}
