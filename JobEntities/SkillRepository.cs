using JobRepository.Model;
using JobRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobRepository
{
    public class SkillRepository : ISkillRepo
    {
        private static List<Skill> skills = new List<Skill>();

        public void AddSkill(Skill skill)
        {
            skills.Add(skill);
        }

        public List<Skill> GetAllSkills() => skills;

        public Skill GetSkillById(int id)
        {
            return skills.FirstOrDefault(s => s.SkillID == id);
        }

        public Skill GetSkillByName(string name)
        {
            return skills.FirstOrDefault(s => s.SkillName == name);
        }

        public List<Skill> GetSkillsByCategory(string category)
        {
            return skills.Where(s => s.Category == category).ToList();
        }

        public void UpdateSkill(Skill skill)
        {
            var existingSkill = GetSkillById(skill.SkillID);
            if (existingSkill != null)
            {
                existingSkill.SkillName = skill.SkillName;
                existingSkill.Category = skill.Category;
            }
        }

        public void DeleteSkill(int id)
        {
            var skill = GetSkillById(id);
            if (skill != null)
            {
                skills.Remove(skill);
            }
        }
    }
}
