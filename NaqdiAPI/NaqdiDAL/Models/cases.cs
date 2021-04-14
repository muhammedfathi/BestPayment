using System;
using System.Collections.Generic;
namespace NaqdiDAL.Models
{
  
    
    public  class cases
    {
       
    
        public int ID { get; set; }
        public double StartValue { get; set; }
        public double EndValue { get; set; }
        //public bool FeesType { get; set; }
        //public decimal FeesValue { get; set; }
        //public bool CommissionType { get; set; }
        //public decimal CommisionValue { get; set; }
        public virtual ICollection<CasesCPS> CasesCPS { get; set; }
    }
}
