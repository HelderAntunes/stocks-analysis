using System;
using System.Collections.Generic;
using System.Text;

namespace AppCMOV2.Models
{
    class QuoteItem
    {
        public string symbol { get; set; }
        public string name { get; set; }
        public string tradeTimestamp { get; set; }
        public double lastPrice { get; set; }
        public double netChange { get; set; }
        public double percentChange { get; set; }
        public string companyName { get; set; }
        public string image { get; set; }
        public string currentInfo { get; set; }
        public string changeInfo { get; set; }
        public string color { get; set; }
    }
}
