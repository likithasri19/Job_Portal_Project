using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobRepository.Model
{
    public class Notification
    {
        public int NotificationID { get; set; }

        
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }

        public string Type { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedDate { get; set; }
    }

}
