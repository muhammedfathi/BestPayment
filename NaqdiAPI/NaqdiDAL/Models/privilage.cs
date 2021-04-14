using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NaqdiDAL.Models
{
  
    
    public  class privilage
    {
       
    
        public int ID { get; set; }
        public string Title { get; set; }

        [ForeignKey("Service")]
        public int? service_id { get; set; }

        [ForeignKey("Company")]
        public int? company_id { get; set; }

        public int? upServiceId { get; set; }

        public virtual Service  Service { get; set; }
        public virtual Company Company { get; set; }

        public virtual ICollection<Rol_PrivFT> Rol_PrivFT { get; set; }
    }
}
