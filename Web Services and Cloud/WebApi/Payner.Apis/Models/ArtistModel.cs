using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Payner.Models;

namespace Payner.Apis.Models
{
    public class ArtistModel
    {
        public int ArtistId { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public static Expression<Func<Artist, ArtistModel>> FromArtist
        {
            get
            {
                return x => new ArtistModel()
                {
                    ArtistId = x.ArtistId,
                    Name = x.Name,
                    Country = x.Country,
                    DateOfBirth = x.DateOfBirth,
                };
            }
        }

        public Artist ToArtist()
        {
            return new Artist()
            {
                ArtistId = this.ArtistId,
                Country = this.Country,
                DateOfBirth = this.DateOfBirth,
                Name = this.Name
            };
        }

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
        }
    }
}