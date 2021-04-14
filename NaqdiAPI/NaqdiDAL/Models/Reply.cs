using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NaqdiDAL.Models
{
    
    public class Reply
    {
        public int ID { get; set; }
        public string Reply1 { get; set; }
        [ForeignKey("Complaint")]
        public int CompliaintID { get; set; }

        [ForeignKey("TUser")]
        public int ReplyedByIDFK { get; set; }
        
        public DateTime? ReplyedON {get; set;}
    
        public virtual Complaint Complaint { get; set; }
        public virtual TUser TUser {get; set;}
    }
}
