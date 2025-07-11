using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace JobRepository.Model
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int DepartmentID { get; set; }
        [ForeignKey("DepartmentID")]
        public Department Department { get; set; }

        public int? ManagerID { get; set; }
        [ForeignKey("ManagerID")]
        public Manager Manager { get; set; }

        public string Role { get; set; }
        public DateTime JoinDate { get; set; }

        // Navigation
       
    }

}
