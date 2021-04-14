using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NaqdiDAL.Models
{
     public  class Fields_Mapping
    {

        public int ID { get; set; }

        public string AndroidName { get; set; }

        public bool IsRequest { get; set; }

        public string ProviderName { get; set; }

        [ForeignKey("Service_Provider")]
        public int Service_ProviderID { get; set; }

        public virtual Service_Provider Service_Provider { get; set; }

    }
}
