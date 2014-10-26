using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaptopSystem.App.Models
{
    public class SearchModel
    {
        public string ManufacturerSearchText { get; set; }

        public string ModelSearchText { get; set; }

        public string PriceNumeric { get; set; }
    }
}