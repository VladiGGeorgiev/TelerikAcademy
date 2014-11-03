using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Web;

namespace Payner.Models
{
    public class Artist
    {
        public Artist()
        {
            this.Songs = new List<Song>();
            this.Albums = new List<Album>();
        }

        public int ArtistId { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public ICollection<Song> Songs { get; set; }

        public ICollection<Album> Albums { get; set; }
        
        public void Update(Artist artist)
        {
            if (this.Name != null)
            {
                artist.Name = this.Name;
            }
            if (this.Country != null)
            {
                artist.Country = this.Country;
            }
            if (this.DateOfBirth != null)
            {
                artist.DateOfBirth = this.DateOfBirth;
            }
            if (this.Songs != null)
            {
                artist.Songs = this.Songs;
            }
            if (this.Albums != null)
            {
                artist.Albums = this.Albums;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Artist-> ");
            result.Append(string.Format("Name: {0}", this.Name));
            result.Append(string.Format(", Country: {0}", this.Country));
            result.Append(string.Format(", Birth: {0}", this.DateOfBirth));
            if (Songs != null)
            {
                result.Append(string.Format(", Songs: "));
                foreach (var song in Songs)
                {
                    result.Append(song.Title + ", ");
                }
                result.Length -= 2;
            }

            if (Albums != null)
            {
                result.Append(", Albums: ");
                foreach (var album in Albums)
                {
                    result.Append(album.Title + ", ");
                }
                result.Length -= 2;
            }

            return result.ToString();
        }
    }
}