using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobRepository.Model
{
    public class JobSkill
    {
        public int JobSkillID { get; set; }
        public int JobID { get; set; }
        [ForeignKey("JobID")]

        public Job Job { get; set; }

        public int SkillID { get; set; }

        [ForeignKey("SkillID")]
        public Skill Skill { get; set; }

        public bool IsRequired { get; set; }
    }

}
