using System;
using System.Collections.Generic;
namespace NaqdiDAL.Models
{
   
    
    public  class Company
    {
        
    
        public int ID { get; set; }
        public string name { get; set; }

        public virtual ICollection<CasesCPS> CasesCPS { get; set; }

      
        //public virtual ICollection<CPService> CPService { get; set; }
        public virtual ICollection<Excute> Excute { get; set; }
        public virtual ICollection<Log> Log { get; set; }
        public virtual ICollection<Store> Store { get; set; }
    }
}
