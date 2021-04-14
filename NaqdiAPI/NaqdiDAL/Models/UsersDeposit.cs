using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NaqdiDAL.Models
{
   
    public  class UsersDeposit
    {
        public int ID { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Bank")]
        public int? BankID { get; set; }
        public DateTime? Date { get; set; }
        public decimal Value { get; set; }
        public bool FeesType { get; set; }
        public decimal? FeesValue { get; set; }
        public decimal? NetValue { get; set; }
        public string Desc { get; set; }

        [ForeignKey("User1")]
        public int ResposibleID { get; set; }
        public bool Type { get; set; }
        public string image_Path { get; set; }
        public byte[] Image_Bytes { get; set; }
        public bool state { get; set; }
        public string MoveType { get; set; }

        [ForeignKey("User2")]
        public int ToUser { get; set; }

        public virtual Banks Banks { get; set; }
        public virtual TUser User { get; set; }
        public virtual TUser User1 { get; set; }

        public virtual TUser User2 { get; set; }


    }
}
