using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NaqdiDAL.Models
{
    public class CasesCPSField_Prov
    {
        public int ID { get; set; }

        [ForeignKey("CasesCPS")]
        public int CasesCPS_ID { get; set; }

        public string fieldName { get; set; }

        public string fieldValue { get; set; }

        public virtual CasesCPS CasesCPS { get; set; }

    }
}
