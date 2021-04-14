using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NaqdiDAL.Models
{
   
    public  class Excute
    {
        public int ID { get; set; }
        public System.DateTime dateIn { get; set; }
        public string status { get; set;}
        public decimal value { get; set;}


        [ForeignKey("Service")]
        public int service_id { get; set;}


        [ForeignKey("TUser")]
        public int user_id { get; set;}

        [ForeignKey("Company")]
        public int? company_id { get; set;}

        [ForeignKey("Provider")]
        public int? provider_id { get; set;}
       
        public decimal? DiscValue { get; set;}
        public decimal? Fees { get; set;}
        public decimal? Commission { get; set;}
        public DateTime? DateOut { get; set;}
        public string TimeIn { get; set;}
        public string TimeOut { get; set;}
        public string PhoneNo { get; set;}

        [ForeignKey("TUser1")]
        public int FinalUser { get; set;}
        public string CardID { get; set; }

        

        public virtual Company Company { get; set; }
        public virtual Service Service { get; set; }
        public virtual TUser TUser { get; set; }
        public virtual TUser TUser1 { get; set; }
        public virtual Provider Provider { get; set; }
    }
}
