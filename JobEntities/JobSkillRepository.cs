using JobRepository.Model;
using JobRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobRepository
{
    public class JobSkillRepository : IJobSkillRepo
    {
        private static List<JobSkill> jobSkills = new List<JobSkill>();

        public void AddJobSkill(JobSkill jobSkill)
        {
            jobSkills.Add(jobSkill);
        }

        public List<JobSkill> GetAllJobSkills() => jobSkills;

        public List<JobSkill> GetJobSkills(int jobId)
        {
            return jobSkills.Where(js => js.JobID == jobId).ToList();
        }

        public JobSkill GetJobSkill(int jobId, int skillId)
        {
            return jobSkills.FirstOrDefault(js => js.JobID == jobId && js.SkillID == skillId);
        }

        public void UpdateJobSkill(JobSkill jobSkill)
        {
            var existing = GetJobSkill(jobSkill.JobID, jobSkill.SkillID);
            if (existing != null)
            {
                existing.IsRequired = jobSkill.IsRequired;
            }
        }

        public void DeleteJobSkill(int jobId, int skillId)
        {
            var jobSkill = GetJobSkill(jobId, skillId);
            if (jobSkill != null)
            {
                jobSkills.Remove(jobSkill);
            }
        }
    }
}
