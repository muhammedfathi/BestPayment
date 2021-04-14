using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NaqdiDAL.Models
{
    
    public  class Log
    {
        public int ID { get; set; }
        public string request { get; set; }
        public string response { get; set; }

        [ForeignKey("Provider")]
        public int? providerid { get; set; }

        [ForeignKey("Company")]
        public int? companyid { get; set; }

        [ForeignKey("Service")]
        public int? serviceid { get; set; }


        [ForeignKey("TUser")]
        public int? userid { get; set; }
        public System.DateTime? ldate { get; set; }
        public string accountno { get; set; }



        public virtual Company Company { get; set; }
        public virtual Service Service { get; set; }
        public virtual TUser TUser { get; set; }
        public virtual Provider Provider { get; set; }
    }
}
