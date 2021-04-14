using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NaqdiDAL.Models
{
    public class Execution_Response
    {
        public int ID { get; set; }

        [ForeignKey("Excute")]
        public int  ExecutionID { get; set; }

        public string  fieldName { get; set; }

        public int fieldValue { get; set; }

        //
        public virtual Excute Excute { get; set; }

    }
}
