using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace JobRepository.Model
{
    public class Job
    {
        public int JobID { get; set; }
        public string Title { get; set; }

        public int DepartmentID { get; set; }
        [ForeignKey("DepartmentID")]

        public Department ?Department { get; set; }

        public int LocationID { get; set; }
        [ForeignKey("LocationID")]
        public Location? Location { get; set; }

        public string Description { get; set; }
        public string Requirements { get; set; }
        public bool Status { get; set; }
        public string PostedBy { get; set; }
        public DateTime PostedDate { get; set; }

        // Navigation
        
    }

}
