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
    public class JobsService : IJobService
    {
        private readonly IJobRepo _jobRepo;

        public JobsService(IJobRepo jobRepo)
        {
            _jobRepo = jobRepo;
        }

        public void CreateJob(Job job)
        {
            job.PostedDate = DateTime.Now;
            job.Status = true;
            _jobRepo.AddJob(job);
        }

        public List<Job> GetAllJobs()
        {
            return _jobRepo.GetAllJobs();
        }

        public Job GetJobById(int id)
        {
            return _jobRepo.GetJobById(id);
        }

        public List<Job> GetActiveJobs()
        {
            return _jobRepo.GetActiveJobs();
        }

        public List<Job> SearchJobs(string keyword)
        {
            return _jobRepo.SearchJobs(keyword);
        }

        public List<Job> FilterJobs(int? departmentId, int? locationId, string keyword)
        {
            var jobs = _jobRepo.GetAllJobs();

            if (departmentId.HasValue)
                jobs = jobs.Where(j => j.DepartmentID == departmentId.Value).ToList();

            if (locationId.HasValue)
                jobs = jobs.Where(j => j.LocationID == locationId.Value).ToList();

            if (!string.IsNullOrEmpty(keyword))
                jobs = jobs.Where(j => j.Title.Contains(keyword) ||
                                      j.Description.Contains(keyword) ||
                                      j.Requirements.Contains(keyword)).ToList();

            return jobs;
        }

        public void UpdateJob(Job job)
        {
            _jobRepo.UpdateJob(job);
        }

        public void DeleteJob(int id)
        {
            _jobRepo.DeleteJob(id);
        }
    }

}
