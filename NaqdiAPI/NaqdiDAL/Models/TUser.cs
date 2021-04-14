using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NaqdiDAL.Models
{
   
    public class TUser
    {
       
    
        [Key]
        public int UserId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string DateIN { get; set; }

        [ForeignKey("User")]
        public int? UPUser { get; set; }
        public decimal? Balance { get; set; }
        //public int? GroupId { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public string CardID { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string PhoneNo1 { get; set; }
        public string Email { get; set; }
        public bool? State { get; set; }

        [ForeignKey("Role")]
        public int Role_ID { get; set; }


     
        public virtual ICollection<Complaint> Complaint { get; set; }
        public virtual ICollection<Excute> Excute { get; set; }
        public virtual ICollection<Excute> Excute1 { get; set; }
        public virtual ICollection<Log> Log { get; set; }
        public virtual ICollection<ProvidersDeposit> ProvidersDeposit { get; set; }
        public virtual ICollection<Reply> Reply { get; set; }
        public virtual ICollection<Rol_PrivFT> Rol_PrivFT { get; set; }
        public virtual Role Role { get; set; }
        public virtual TUser User { get; set; }

        //  public virtual ICollection<Safe> Safe { get; set; }
        public virtual ICollection<UsersDeposit> UsersDeposit { get; set; }
        public virtual ICollection<UsersDeposit> UsersDeposit1 { get; set; }

        public virtual ICollection<UsersDeposit> UsersDeposit2 { get; set; }

    }
}
