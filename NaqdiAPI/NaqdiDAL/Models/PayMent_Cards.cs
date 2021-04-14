using System;
using System.Collections.Generic;
namespace NaqdiDAL.Models
{
   
    
    public  class PayMent_Cards
    {
        public int id { get; set; }
        public string phoneno { get; set; }
        public decimal? bill_value { get; set; }
        public DateTime? EDate { get; set; }
        public decimal? paid_value { get; set; }
        public decimal? Residual_Value { get; set; }
        public int? Cards_Count { get; set; }
        public string Pay_Desc { get; set; }
    }
}
