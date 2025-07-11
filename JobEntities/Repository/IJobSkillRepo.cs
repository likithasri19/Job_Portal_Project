using JobRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobRepository.Repository
{

        public interface IJobSkillRepo
        {
            void AddJobSkill(JobSkill jobSkill);
            List<JobSkill> GetAllJobSkills();
            List<JobSkill> GetJobSkills(int jobId);
            JobSkill GetJobSkill(int jobId, int skillId);
            void UpdateJobSkill(JobSkill jobSkill);
            void DeleteJobSkill(int jobId, int skillId);
        }

    }

