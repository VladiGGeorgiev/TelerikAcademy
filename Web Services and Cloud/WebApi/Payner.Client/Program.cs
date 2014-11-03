using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payner.Apis.Models;
using Payner.Data;
using Payner.Models;
using System.Data.Entity;
using Payner.Data.Migrations;

namespace Payner.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PaynerContext, Configuration>());

//            Album dbAlbum = JsonClient.Albums.Add(new AlbumModel()
//                {
//                    Title = "Last last album",
//                    Producer = "Bay Pesho last",
//                    Year = new DateTime(2012, 12, 2)
//                });
//
//            Artist myartist = JsonClient.Artists.AddArtist(new ArtistModel()
//                {
//                    Name = "PPPPPPP",
//                    Country = "sSSSSSSSSSS",
//                    DateOfBirth = new DateTime(1999, 1, 21)
//                });
//            
//            dbAlbum.Artists.Add(myartist);
//
//            JsonClient.Albums.Edit(dbAlbum.AlbumId, dbAlbum);

            Album album = JsonClient.Albums.Add(new AlbumModel()
                {
                    Title = "Hi Albym",
                    Producer = "Kiro Mirov",
                    Year = new DateTime(2005, 9, 12)
                });

            Song song = JsonClient.Songs.Add(new SongModel()
                {
                    Title = "Ela mi",
                    Genre = "Rap",
                });

            album.Songs.Add(song);

            JsonClient.Albums.Edit(album.AlbumId, album);

//            Song song = JsonClient.Songs.GetSong()
//
//            Artist artist = JsonClient.Artists.AddArtist(new ArtistModel()
//                {
//                    Name = "Duda",
//                    Country = "USA",
//                    DateOfBirth = new DateTime(1995, 8, 15)
//                });
//
//            artist.Songs.Add(song);
//            JsonClient.Artists.EditArtist(artist.ArtistId, artist);
        }
    }
}

//Album add artist
//Song add album

//Song add artist -> Works
//Artist add album
//Artist add song -> Works but added new song not used from db.
    //Add song
    //Add artist
    //Add song to artist
    //Edit artist
//Album add song