using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NaqdiDAL.Models
{
    public class Service_Provider
    {
        [Key]
        public int Serv_ProvID { get; set; }


        public string ServiceName { get; set; }//GAsInq/Pay... service 3andna e7na

        public string Key { get; set; }//Inquery?Payment (#....)
        public string ID { get; set; }//Id For ProviderLike(cassescpsId)
        public string ServiceVerb {get;set;}// get/.post/....

        [ForeignKey("CasesCPS")]
        public int CasesCpsID { get; set; }

        public virtual CasesCPS CasesCPS { get; set; }



        //public virtual Service service { get; set; }
        //public virtual Company company { get; set; }
        //public virtual Provider provider { get; set; }










    }
}
