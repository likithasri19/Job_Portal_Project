using JobRepository.Model;
using JobRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobRepository
{
    public class UserSkillRepository : IUserSkillRepo
    {
        private static List<UserSkill> userSkills = new List<UserSkill>();

        public void AddUserSkill(UserSkill userSkill)
        {
            userSkills.Add(userSkill);
        }

        public List<UserSkill> GetAllUserSkills() => userSkills;

        public List<UserSkill> GetUserSkills(int userId)
        {
            return userSkills.Where(us => us.UserID == userId).ToList();
        }

        public UserSkill GetUserSkill(int userId, int skillId)
        {
            return userSkills.FirstOrDefault(us => us.UserID == userId && us.SkillID == skillId);
        }

        public void UpdateUserSkill(UserSkill userSkill)
        {
            var existing = GetUserSkill(userSkill.UserID, userSkill.SkillID);
            if (existing != null)
            {
                existing.ProficiencyLevel = userSkill.ProficiencyLevel;
            }
        }

        public void DeleteUserSkill(int userId, int skillId)
        {
            var userSkill = GetUserSkill(userId, skillId);
            if (userSkill != null)
            {
                userSkills.Remove(userSkill);
            }
        }
    }

}
