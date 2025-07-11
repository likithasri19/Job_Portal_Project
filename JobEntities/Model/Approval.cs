using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JobRepository.Model
{
    public class Approval
    {
        public int ApprovalID { get; set; }

        public int ApplicationID { get; set; }

        [ForeignKey("ApplicationID")]
        [JsonIgnore]
        public Application Application { get; set; }

        public int ApproverID { get; set; }
        [ForeignKey("ApproverID")]
        [JsonIgnore]
        public User Approver { get; set; }

        public int ApprovalLevel { get; set; }
        public bool Status { get; set; }
        public string Comments { get; set; }
        public DateTime Date { get; set; }
    }

}
