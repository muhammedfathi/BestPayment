using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NaqdiDAL.Models
{
   
    
    public partial class Complaint
    {
        public int ID { get; set; }
        public string Content { get; set; }

        [ForeignKey("TUser")]
        public int ComplaintUserOwnerIDFK { get; set; }
        public string cdate { get; set; }
    
        public virtual TUser TUser { get; set; }

        public virtual ICollection<Reply> Reply { get; set; }
    }
}
