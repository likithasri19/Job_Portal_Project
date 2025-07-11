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
    public class SkillsMatchingService : ISkillsMatchingService
    {
        private readonly IUserSkillRepo _userSkillRepo;
        private readonly IJobSkillRepo _jobSkillRepo;
        private readonly IJobRepo _jobRepo;
        private readonly IUserRepo _userRepo;

        public SkillsMatchingService(IUserSkillRepo userSkillRepo, IJobSkillRepo jobSkillRepo, IJobRepo jobRepo, IUserRepo userRepo)
        {
            _userSkillRepo = userSkillRepo;
            _jobSkillRepo = jobSkillRepo;
            _jobRepo = jobRepo;
            _userRepo = userRepo;
        }

        public List<Job> GetMatchingJobs(int userId)
        {
            var userSkills = _userSkillRepo.GetUserSkills(userId);
            var userSkillIds = userSkills.Select(us => us.SkillID).ToList();
            var allJobs = _jobRepo.GetActiveJobs();
            var matchingJobs = new List<Job>();

            foreach (var job in allJobs)
            {
                var jobSkills = _jobSkillRepo.GetJobSkills(job.JobID);
                var jobSkillIds = jobSkills.Select(js => js.SkillID).ToList();

                if (userSkillIds.Any(us => jobSkillIds.Contains(us)))
                {
                    matchingJobs.Add(job);
                }
            }

            return matchingJobs;
        }

        public List<User> GetMatchingCandidates(int jobId)
        {
            var jobSkills = _jobSkillRepo.GetJobSkills(jobId);
            var jobSkillIds = jobSkills.Select(js => js.SkillID).ToList();
            var allUsers = _userRepo.GetAllUsers();
            var matchingUsers = new List<User>();

            foreach (var user in allUsers)
            {
                var userSkills = _userSkillRepo.GetUserSkills(user.UserID);
                var userSkillIds = userSkills.Select(us => us.SkillID).ToList();

                if (jobSkillIds.Any(js => userSkillIds.Contains(js)))
                {
                    matchingUsers.Add(user);
                }
            }

            return matchingUsers;
        }

        public int CalculateSkillMatchPercentage(int userId, int jobId)
        {
            var userSkills = _userSkillRepo.GetUserSkills(userId);
            var jobSkills = _jobSkillRepo.GetJobSkills(jobId);

            var userSkillIds = userSkills.Select(us => us.SkillID).ToList();
            var jobSkillIds = jobSkills.Select(js => js.SkillID).ToList();

            var matchingSkills = userSkillIds.Intersect(jobSkillIds).Count();

            if (jobSkillIds.Count == 0)
                return 0;

            return (matchingSkills * 100) / jobSkillIds.Count;
        }

        public void AddUserSkill(int userId, int skillId, string proficiencyLevel)
        {
            var userSkill = new UserSkill
            {
                UserID = userId,
                SkillID = skillId,
                ProficiencyLevel = proficiencyLevel
            };

            _userSkillRepo.AddUserSkill(userSkill);
        }

        public void AddJobSkill(int jobId, int skillId, bool isRequired)
        {
            var jobSkill = new JobSkill
            {
                JobID = jobId,
                SkillID = skillId,
                IsRequired = isRequired
            };

            _jobSkillRepo.AddJobSkill(jobSkill);
        }
    }
    }
