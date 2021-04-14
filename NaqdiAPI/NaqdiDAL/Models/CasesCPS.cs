using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NaqdiDAL.Models
{
    public class CasesCPS
    {
        public int ID { get; set; }

        [ForeignKey("Company")]
        public int Comapny_id { get; set; }

        [ForeignKey("Provider")]
        public int Provider_id { get; set; }

        [ForeignKey("Service")]
        public int Service_id { get; set; }

        [ForeignKey("cases")]
        public int Cases_id { get; set; }
        public bool? FeesType { get; set; }
        public decimal? FeesValue { get; set; }
        public bool? CommissionType { get; set; }
        public decimal? CommissionValue { get; set; }

        public bool QueryState { get; set; }
        public bool PaymentState { get; set; }

        public bool ISEnabled { get; set; }

        //public int? CPServiceID { get; set; }




        public virtual cases cases { get; set; }
        public virtual Company Company { get; set; }
        //public virtual CPService CPService { get; set; }
        public virtual Service Service { get; set; }
        public virtual Provider Provider { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
        public virtual ICollection<CasesCPSField_Prov> CasesCPSField_Provs { get; set; }
        public virtual ICollection<Service_Provider> Service_Providers { get; set; }
    
    }
}
