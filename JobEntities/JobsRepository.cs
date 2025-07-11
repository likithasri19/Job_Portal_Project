using JobRepository.Model;
using JobRepository.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobRepository
{
    public class JobsRepository : IJobRepo
    {
        private readonly JobPortalContext _context;

        public JobsRepository(JobPortalContext context)
        {
            _context = context;
        }

        public void AddJob(Job job)
        {
            _context.Jobs.Add(job);
            _context.SaveChanges();
        }

        public List<Job> GetAllJobs()
        {
            return _context.Jobs
                .Include(j => j.Department)
                .Include(j => j.Location)
                .ToList();
        }

        public Job GetJobById(int id)
        {
            return _context.Jobs
                .Include(j => j.Department)
                .Include(j => j.Location)
                .FirstOrDefault(j => j.JobID == id);
        }

        public List<Job> GetActiveJobs()
        {
            return _context.Jobs
                .Include(j => j.Department)
                .Include(j => j.Location)
                .Where(j => j.Status == true)
                .ToList();
        }

        public List<Job> GetJobsByDepartment(int departmentId)
        {
            return _context.Jobs
                .Include(j => j.Department)
                .Include(j => j.Location)
                .Where(j => j.DepartmentID == departmentId)
                .ToList();
        }

        public void UpdateJob(Job job)
        {
            _context.Jobs.Update(job);
            _context.SaveChanges();
        }

        public void DeleteJob(int id)
        {
            var job = _context.Jobs.Find(id);
            if (job != null)
            {
                _context.Jobs.Remove(job);
                _context.SaveChanges();
            }
        }

        public List<Job> SearchJobs(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                return new List<Job>();

            return _context.Jobs
                .Include(j => j.Department)
                .Include(j => j.Location)
                .Where(j => j.Title.Contains(keyword) ||
                           j.Description.Contains(keyword) ||
                           j.Requirements.Contains(keyword) ||
                           j.Department.DepartmentName.Contains(keyword) ||
                           j.Location.LocationName.Contains(keyword))
                .ToList();
        }
    }
}