using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Runtime.Serialization;

namespace Payner.Models
{
    public class Album
    {
        public Album()
        {
            this.Artists = new List<Artist>();
            this.Songs = new List<Song>();
        }
        
        public int AlbumId { get; set; }

        public string Title { get; set; }

        public DateTime? Year { get; set; }

        public string Producer { get; set; }

        public ICollection<Artist> Artists { get; set; }

        public ICollection<Song> Songs { get; set; }

        public void Update(Album album)
        {
            if (this.Title != null)
            {
                album.Title = this.Title;
            }
            if (this.Producer != null)
            {
                album.Producer = this.Producer;
            }
            if (this.Year != null)
            {
                album.Year = this.Year;
            }
            if (this.Songs != null)
            {
                album.Songs = this.Songs;
            }
            if (this.Artists != null)
            {
                album.Artists = this.Artists;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Album-> ");
            result.Append(string.Format("Title: {0}", this.Title));
            result.Append(string.Format(", Year: {0}", this.Year));
            result.Append(string.Format(", Producer: {0}", this.Producer));
            if (Artists != null)
            {
                result.Append(string.Format(", Artists: "));
                foreach (var artist in Artists)
                {
                    result.Append(artist.Name + ", ");
                }
                result.Length -= 2;
            }

            if (Songs != null)
            {
                result.Append(", Songs: ");
                foreach (var song in Songs)
                {
                    result.Append(song.Title + ", ");
                }
                result.Length -= 2;
            }

            return result.ToString();
        }
    }
}