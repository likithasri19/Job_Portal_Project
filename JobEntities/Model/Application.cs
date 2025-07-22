using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JobRepository.Model
{
    public class Application
    {
        public int ApplicationID { get; set; }

        public int JobID { get; set; }

        [ForeignKey("JobID")]
        public Job Job { get; set; }

        public int UserID { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }

        public int ManagerID { get; set; }
        [ForeignKey("ManagerID")]
        public Manager Manager { get; set; }

        public DateTime ApplicationDate { get; set; }
        public bool Status { get; set; }
        public string CoverLetter { get; set; }

        public string ResumePath { get; set; }

        public string Experience { get; set; }




    }

}
