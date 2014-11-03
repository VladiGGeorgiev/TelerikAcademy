using System;
using System.Collections.Generic;
using System.Net.Http;
using Payner.Models;

namespace Payner.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonClient.Artists.AddArtist("Pesho Dyrvoto", "Russia", new DateTime(1977, 2, 10));
            JsonClient.Artists.AddArtist("Ivan Mentata", "Brazil", new DateTime(1997, 2, 10));
            JsonClient.Artists.AddArtist("John Ivanov", "England", new DateTime(1978, 2, 10));
            JsonClient.Artists.AddArtist("Minka Svircholini", "Russia", new DateTime(1997, 4, 10));
            JsonClient.Artists.AddArtist("Pepa Prashkata", "Russia", new DateTime(1987, 6, 10));
            JsonClient.Artists.AddArtist("Teodor Keracudata", "Russia", new DateTime(1979, 3, 10));
            JsonClient.Artists.DeleteArtist(6);
            JsonClient.Artists.EditArtist(11, "Jivko Donev", "Romenia", new DateTime(1991, 2, 14));
            JsonClient.Artists.ShowAllArtists();
            Artist artist = JsonClient.Artists.GetArtist(9);
            Song song = JsonClient.Songs.GetSong(4);
            //JsonClient.Songs.Add(new Song { Artist = artist, Genre = "Classic", Title = "Love me", Year = DateTime.Now });
            //JsonClient.Songs.Edit(5, new Song { Artist = artist, Genre = "BG Rap", Title = "Hate me", Year = DateTime.Now });
            JsonClient.Songs.GetAllSongs();

            JsonClient.Albums.Add("Love", "Payner", DateTime.Now, new List<Artist>() { artist }, new List<Song>() { song });
            JsonClient.Albums.Add("Bitches", "ARA", DateTime.Now, new List<Artist>() { artist }, new List<Song>() { song });
            JsonClient.Albums.Add("X Files", "Payner", DateTime.Now, new List<Artist>() { artist }, new List<Song>() { song });
        }
    }
}
