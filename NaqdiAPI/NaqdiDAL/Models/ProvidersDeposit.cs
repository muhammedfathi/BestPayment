using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NaqdiDAL.Models
{
   
    public  class ProvidersDeposit
    {
        public int ID { get; set; }

        [ForeignKey("Provider")]
        public int? ProviderID { get; set; }

        [ForeignKey("Banks")]
        public int? BankID { get; set; }
       
        public decimal? Value { get; set; }
        public string Date { get; set; }
        public string Desc { get; set; }

        [ForeignKey("TUser")]
        public int? UserID { get; set; }

        public virtual Banks Banks { get; set; }
        public virtual TUser TUser { get; set; }
        public virtual Provider Provider { get; set; }
    }
}
