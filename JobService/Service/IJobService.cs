using JobRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobService.Service
{
    public interface IJobService
    {
        void CreateJob(Job job);
        List<Job> GetAllJobs();
        Job GetJobById(int id);
        List<Job> GetActiveJobs();
        List<Job> SearchJobs(string keyword);
        List<Job> FilterJobs(int? departmentId, int? locationId, string keyword);
        void UpdateJob(Job job);
        void DeleteJob(int id);
    }
}
