using JobRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobRepository.Repository
{
    public interface IJobRepo
    {
        void AddJob(Job job);
        List<Job> GetAllJobs();
        Job GetJobById(int id);
        List<Job> GetActiveJobs();
        List<Job> GetJobsByDepartment(int departmentId);
        void UpdateJob(Job job);
        void DeleteJob(int id);
        List<Job> SearchJobs(string keyword);
    }
}
