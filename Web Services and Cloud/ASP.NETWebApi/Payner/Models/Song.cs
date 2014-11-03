using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payner.Models
{
    public class Song
    {
        public int SongId { get; set; }

        public string Title { get; set; }

        public DateTime Year { get; set; }

        public string Genre { get; set; }

        public Artist Artist { get; set; }
    }
}