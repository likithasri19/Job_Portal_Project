using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobRepository.Model
{
    public class UserSkill
    {
        public int UserSkillID { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }

        public int SkillID { get; set; }
        [ForeignKey("SkillID")]
        public Skill Skill { get; set; }

        public string ProficiencyLevel { get; set; }
    }

}
