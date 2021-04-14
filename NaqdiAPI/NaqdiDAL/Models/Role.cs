using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NaqdiDAL.Models
{
   
    public class Role
    {
        public int ID { get; set; }
        [Required]
        public string name { get; set; }


        public virtual ICollection<Rol_PrivFT> Rol_PrivFT { get; set; }
        public virtual ICollection<TUser> TUser { get; set; }
    }
}
