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
    public class SkillService : ISkillService
    {
        private readonly ISkillRepo _skillRepo;

        public SkillService(ISkillRepo skillRepo)
        {
            _skillRepo = skillRepo;
        }

        public void AddSkill(Skill skill)
        {
            _skillRepo.AddSkill(skill);
        }

        public List<Skill> GetAllSkills()
        {
            return _skillRepo.GetAllSkills();
        }

        public Skill GetSkillById(int id)
        {
            return _skillRepo.GetSkillById(id);
        }

        public List<Skill> GetSkillsByCategory(string category)
        {
            return _skillRepo.GetSkillsByCategory(category);
        }

        public void UpdateSkill(Skill skill)
        {
            _skillRepo.UpdateSkill(skill);
        }

        public void DeleteSkill(int id)
        {
            _skillRepo.DeleteSkill(id);
        }
    }

}
