using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FbmMobileApp.ViewModels
{
    public class StudioModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Town { get; set; }

        public string Picture { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }
    }
}