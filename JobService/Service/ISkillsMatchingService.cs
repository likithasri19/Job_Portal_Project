using JobRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobService.Service
{
    public interface ISkillsMatchingService
    {
        List<Job> GetMatchingJobs(int userId);
        List<User> GetMatchingCandidates(int jobId);
        int CalculateSkillMatchPercentage(int userId, int jobId);
        void AddUserSkill(int userId, int skillId, string proficiencyLevel);
        void AddJobSkill(int jobId, int skillId, bool isRequired);
    }
}
