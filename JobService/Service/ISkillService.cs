using JobRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobService.Service
{
    public interface ISkillService
    {
        void AddSkill(Skill skill);
        List<Skill> GetAllSkills();
        Skill GetSkillById(int id);
        List<Skill> GetSkillsByCategory(string category);
        void UpdateSkill(Skill skill);
        void DeleteSkill(int id);
    }
}
