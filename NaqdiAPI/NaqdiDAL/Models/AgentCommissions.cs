using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NaqdiDAL.Models
{
    public class AgentCommissions
    {

        public int ID { get; set; }
        [ForeignKey("user")]
        public int UserID { get; set; }

        [ForeignKey("Service")]
        public int? Service_ID { get; set; }

        [ForeignKey("Company")]
        public int? Company_ID { get; set; }

        
        [ForeignKey("Provider")]
        public int? Provider_ID { get; set; }

       
        [ForeignKey("cases")]
        public int? Case_ID { get; set; }
        
        public bool? Commission_Type { get; set; }
        public decimal? Commission_Value { get; set; }
        public bool? Fees_Type { get; set; }
        public decimal? Fees_Value { get; set; }
        public bool? PaymentState { get; set; }


        public virtual TUser user { get; set; }
        public virtual Service Service { get; set; }

        public virtual Company Company { get; set; }

        public virtual Provider Provider { get; set; }


        public virtual cases  cases{ get; set; }



    }
}
