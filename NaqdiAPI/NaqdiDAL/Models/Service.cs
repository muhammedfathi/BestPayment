
namespace NaqdiDAL.Models
{
    using System;
    using System.Collections.Generic;
    
    public  class Service
    {
       
    
        public int ID { get; set; }
        public string name { get; set; }
        public string name_en { get; set; }
       // public bool? state { get; set; }
        public bool? MType { get; set; }



        public virtual ICollection<CasesCPS> CasesCPS { get; set; }
      //  public virtual ICollection<CPService> CPService { get; set; }
        public virtual ICollection<Excute> Excute { get; set; }
        public virtual ICollection<Log> Log { get; set; }
     
        public virtual ICollection<Store> Store { get; set; }
       // public virtual ICollection<SubService> subServices {get; set;}




        //public virtual ICollection<Menu> Menu { get; set; }
        //public virtual ICollection<ServiceFieldsFT> ServiceFieldsFT { get; set; }


    }
}
