using JobRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobService.Service
{
    public interface IApplicationService
    {
        void SubmitApplication(int userId, int jobId, string coverLetter);
        List<Application> GetAllApplications();
        Application GetApplicationById(int id);
        List<Application> GetUserApplications(int userId);
        List<Application> GetJobApplications(int jobId);
        void UpdateApplicationStatus(int applicationId, bool status);
        bool HasUserApplied(int userId, int jobId);
    }
}
