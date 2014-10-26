using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCalculator.ViewModel
{
    public class CalculatorViewModel
    {
        public decimal Quantity { get; set; }

        public string Type { get; set; }

        public int Kilo { get; set; }

        public Dictionary<string, decimal> CalculatedUnits { get; set; }
    }
}