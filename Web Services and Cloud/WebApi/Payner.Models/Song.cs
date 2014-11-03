using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Payner.Models
{
    public class Song
    {
        public int SongId { get; set; }

        public string Title { get; set; }

        public DateTime? Year { get; set; }

        public string Genre { get; set; }

        public Artist Artist { get; set; }

        public Album Album { get; set; }

        public void Update(Song song)
        {
            if (this.Title != null)
            {
                song.Title = this.Title;
            }
            if (this.Year != null)
            {
                song.Year = this.Year;
            }
            if (this.Genre != null)
            {
                song.Genre = this.Genre;
            }
            if (this.Artist != null)
            {
                song.Artist = this.Artist;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Song-> ");
            result.Append(string.Format("Title: {0}", this.Title));
            result.Append(string.Format(", Year: {0}", this.Year));
            result.Append(string.Format(", Genre: {0}", this.Genre));
            if (Artist != null)
            {
                result.Append(", " + this.Artist);
            }
            return result.ToString();
        }

        public Song ToSong()
        {
            throw new NotImplementedException();
        }
    }
}