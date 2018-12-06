using System;
using System.Collections.Generic;
using System.Text;

namespace AppCMOV2.Models
{
    class StockItem
    {
        public string symbol { get; set; }
        public string timestamp { get; set; }
        public string tradingDay { get; set; }
        public double open { get; set; }
        public double high { get; set; }
        public double low { get; set; }
        public double close { get; set; }
        public double volume { get; set; }
        // public double openInterest { get; set; }
    }
}
