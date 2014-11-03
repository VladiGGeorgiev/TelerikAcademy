using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payner.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}