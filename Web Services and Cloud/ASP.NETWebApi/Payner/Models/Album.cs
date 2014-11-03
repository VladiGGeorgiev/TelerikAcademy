using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payner.Models
{
    public class Album
    {
        public int AlbumId { get; set; }

        public string Title { get; set; }

        public DateTime Year { get; set; }

        public string Producer { get; set; }

        public ICollection<Artist> Artists { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}