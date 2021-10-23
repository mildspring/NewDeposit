using System;
using System.Collections.Generic;
using System.Text;

namespace TotalReturns
{
    public class SerializedData
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public List<Lot> Lots { get; set; }

        public class Lot
        {
            public string Ticker { get; set; }
            public decimal Quantity { get; set; }
        }
    }
}
