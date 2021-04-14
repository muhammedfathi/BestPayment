using System;
using System.Collections.Generic;
using System.Text;

namespace NaqdiDAL.Models
{
    public class ChargeSim
    {
        public int ID { get; set; }

        public int NetworkID { get; set; }

        public int AccountNumber { get; set; }

        public int Value { get; set; }

        public int Fees { get; set; }

        public int Commision { get; set; }

        public string Note { get; set; }


    }
}
