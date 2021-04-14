using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NaqdiDAL.Models
{
    public class ChargeOperation
    {
        public int ID { get; set; }

        [ForeignKey("user")]
        public int UserID { get; set; }

        public DateTime? OperatioDate { get; set; }

        public TimeSpan? OperatioTime { get; set; }

        public int? Phone { get; set; }

        public int Value { get; set; }

        [ForeignKey("Company")]
        public int CompanyID { get; set; }

        public string responseMSG { get; set; }

        public string Note { get; set; }

        [ForeignKey("Excute")]
        public int  OperationID { get; set; } //ExecutionID

        public bool OperationState { get; set; }




        public virtual Company Company { get; set; }
        public virtual TUser user { get; set; }
        public virtual Excute Excute{ get; set; }

    }
}
