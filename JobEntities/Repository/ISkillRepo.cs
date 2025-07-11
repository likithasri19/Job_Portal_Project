using JobRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobRepository.Repository
{
    public interface ISkillRepo
    {
        void AddSkill(Skill skill);
        List<Skill> GetAllSkills();
        Skill GetSkillById(int id);
        Skill GetSkillByName(string name);
        List<Skill> GetSkillsByCategory(string category);
        void UpdateSkill(Skill skill);
        void DeleteSkill(int id);
    }
}
