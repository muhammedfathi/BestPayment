using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NaqdiDAL.Models
{
   
    public  class Store
    {
        public int ID { get; set; }
        public decimal CardValue { get; set; }
        public string serial { get; set; }
        public string startDate { get; set; }
        public int duration { get; set; }

        [ForeignKey("CasesCPS")]
        public int CaseCPS_ID { get; set; }

        //[ForeignKey("Company")]
        //public int Company_id { get; set; }

        //[ForeignKey("Provider")]
        //public int Provider_id { get; set; }

        //[ForeignKey("Service")]
        //public int Service_id { get; set; }




        public string PinNo { get; set; }
        public bool IsUsed{ get; set; }
      
        public string card_no { get; set; }

        public virtual CasesCPS CasesCPS { get; set; }

        //public virtual Company Company { get; set; }
        //public virtual Service Service { get; set; }

        //public virtual Provider Provider { get; set; }



        //public virtual Static_Services Static_Services { get; set; }

    }
}
