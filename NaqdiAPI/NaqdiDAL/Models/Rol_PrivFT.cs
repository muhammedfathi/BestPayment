using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NaqdiDAL.Models
{
    public class Rol_PrivFT
    {
        public int ID { get; set; }

        [ForeignKey("Role")]
        public int Rol_id { get; set; }

        [ForeignKey("privilage")]
        public int Priv_id { get; set; }

       
        public bool? state { get; set; }

        [ForeignKey("TUser")]
        public int? UserID { get; set; }


        public virtual privilage privilage { get; set; }
        public virtual Role Role { get; set; }
        public virtual TUser TUser { get; set; }
    }
}
