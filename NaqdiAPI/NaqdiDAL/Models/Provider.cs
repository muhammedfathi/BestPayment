using System;
using System.Collections.Generic;


namespace NaqdiDAL.Models
{
  
    public  class Provider
    {
        
    
        public int ID { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string URL { get; set; }
        public int? Center_id { get; set; }
        public string Servisversion { get; set; }
        public decimal? Balance { get; set; }


        public virtual ICollection<CasesCPS> CasesCPS { get; set; }

 
      //  public virtual ICollection<CPService> CPService { get; set; }

        public virtual ICollection<Excute> Excute { get; set; }

        public virtual ICollection<Log> Log { get; set; }
        public virtual ICollection<ProvidersDeposit> ProvidersDeposit { get; set; }

        public virtual ICollection<Store> Store { get; set; }



        //public virtual ICollection<Company_ProviderFT> Company_ProviderFT { get; set; }

    }
}
