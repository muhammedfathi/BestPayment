using System;
using System.Collections.Generic;
namespace NaqdiDAL.Models
{

    
    public class Banks
    {
       
    
        public int ID { get; set; }
        public string Bank_Name { get; set; }
        public int? FeesPercent { get; set; }
    
 
        public virtual ICollection<ProvidersDeposit> ProvidersDeposit { get; set; }
   
        public virtual ICollection<UsersDeposit> UsersDeposit { get; set; }
    }
}
