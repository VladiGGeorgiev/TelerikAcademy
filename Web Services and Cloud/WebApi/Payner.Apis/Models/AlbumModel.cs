using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Web;
using Payner.Models;

namespace Payner.Apis.Models
{
    //[DataContract]
    public class AlbumModel
    {
        public int AlbumId { get; set; }

        public string Title { get; set; }

        public DateTime? Year { get; set; }

        //[DataMember(EmitDefaultValue = true)]
        public string Producer { get; set; }

        public static Expression<Func<Album, AlbumModel>> FromAlbum
        {
            get
            {
                return x => new AlbumModel()
                    {
                        AlbumId = x.AlbumId,
                        Title = x.Title,
                        Year = x.Year,
                        Producer = x.Producer,
                    };
            }
        }

        public Album ToAlbum()
        {
            return new Album()
                {
                    AlbumId = this.AlbumId,
                    Year = this.Year,
                    Title = this.Title,
                    Producer = this.Producer
                };
        }

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
        }
    }
}