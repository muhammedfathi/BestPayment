using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NaqdiDAL.Models
{
 
    public  class Login_Information
    {
        public int id { get; set; }
        public string mac_address { get; set; }
        public double?latitude { get; set; }
        public double? longitude { get; set; }

        [ForeignKey("User")]
        public int user_id { get; set; }
        public DateTime? action_date { get; set; }
        public TimeSpan? action_time { get; set; }
        public string note { get; set; }


        public virtual TUser User { get; set; }


    }
}
