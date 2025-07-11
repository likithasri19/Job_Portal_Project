using JobRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobRepository.Repository
{
    public interface IApplicationRepo
    {
        void AddApplication(Application application);
        List<Application> GetAllApplications();
        Application GetApplicationById(int id);
        List<Application> GetApplicationsByJob(int jobId);
        List<Application> GetApplicationsByUser(int userId);
        void UpdateApplication(Application application);
        bool HasUserApplied(int userId, int jobId);
    }
}
