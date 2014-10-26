using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ajax.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        public string Title { get; set; }

        public string Director { get; set; }

        public string Year { get; set; }

        public virtual LeadingRole LeadingMaleRole { get; set; }

        public virtual LeadingRole LeadingFemaleRole { get; set; }
    }
}

//Title, Director, Year, Leading Male Role, Leading Female Role and their Age, Studio, Studio Address.
