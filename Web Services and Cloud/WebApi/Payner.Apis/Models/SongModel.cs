using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Payner.Models;

namespace Payner.Apis.Models
{
    public class SongModel
    {
        public int SongId { get; set; }

        public string Title { get; set; }

        public DateTime? Year { get; set; }
        
        public string Genre { get; set; }
        
        public static Expression<Func<Song, SongModel>> FromSong
        {
            get
            {
                return x => new SongModel()
                {
                    SongId = x.SongId,
                    Title = x.Title,
                    Year = x.Year,
                    Genre = x.Genre
                };
            }
        }

        public Song ToSong()
        {
            return new Song()
            {
                SongId = this.SongId,
                Year = this.Year,
                Title = this.Title,
                Genre = this.Genre
            };
        }

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
        }
    }
}