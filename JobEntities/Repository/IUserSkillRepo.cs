using JobRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobRepository.Repository
{
    public interface IUserSkillRepo
    {
        void AddUserSkill(UserSkill userSkill);
        List<UserSkill> GetAllUserSkills();
        List<UserSkill> GetUserSkills(int userId);
        UserSkill GetUserSkill(int userId, int skillId);
        void UpdateUserSkill(UserSkill userSkill);
        void DeleteUserSkill(int userId, int skillId);
    }
}
