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
        [JsonIgnore]
        public Job Job { get; set; }

        public int UserID { get; set; }

        [ForeignKey("UserID")]
        [JsonIgnore]
        public User User { get; set; }

        public DateTime ApplicationDate { get; set; }
        public bool Status { get; set; }
        public string CoverLetter { get; set; }

        // Navigation
      
    }

}
