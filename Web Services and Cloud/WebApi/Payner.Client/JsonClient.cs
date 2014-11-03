using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Payner.Apis.Models;
using Payner.Models;

namespace Payner.Client
{
    public static class JsonClient
    {
        private static HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:57986/") };

        static JsonClient()
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static class Artists
        {
            public static Artist AddArtist(ArtistModel artist)
            {
                HttpResponseMessage response = client.PostAsJsonAsync("api/artists", artist).Result;
                var myArtist = response.Content.ReadAsAsync<Artist>().Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Artist added: {0}", artist.Name);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }

                return myArtist;
            }
            
            public static void GetAllArtists()
            {
                HttpResponseMessage response = client.GetAsync("api/artists").Result;

                if (response.IsSuccessStatusCode)
                {
                    var artists = response.Content.ReadAsAsync<IEnumerable<ArtistModel>>().Result;
                    foreach (var artist in artists)
                    {
                        Console.WriteLine(artist);
                    }
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }

            public static ArtistModel GetArtist(int id)
            {
                HttpResponseMessage response = client.GetAsync("api/artists/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    var artist = response.Content.ReadAsAsync<ArtistModel>().Result;
                    Console.WriteLine(artist);
                    return artist;
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                    return null;
                }
            }

            public static void EditArtist(int id, Artist artist)
            {
                artist.ArtistId = id;

                HttpResponseMessage response = client.PutAsJsonAsync("api/artists/" + id, artist).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Artist with id: {0} edited!", id);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }

            public static void DeleteArtist(int id)
            {
                HttpResponseMessage response = client.DeleteAsync("api/artists/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Artist with id: {0} deleted", id);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
        }

        public class Albums
        {
            public static Album Add(AlbumModel album)
            {
                HttpResponseMessage responseMessage = client.PostAsJsonAsync("api/albums", album).Result;
                var myAlbum = responseMessage.Content.ReadAsAsync<Album>().Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    Console.WriteLine("Album added: {0}", album.Title);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)responseMessage.StatusCode, responseMessage.ReasonPhrase);
                }
                
                return myAlbum;
            }

            public static void GetAllAlbums()
            {
                HttpResponseMessage responseMessage = client.GetAsync("api/albums").Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    var albums = responseMessage.Content.ReadAsAsync<IEnumerable<AlbumModel>>().Result;
                    foreach (var album in albums)
                    {
                        Console.WriteLine(album);
                    }
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)responseMessage.StatusCode, responseMessage.ReasonPhrase);
                }
            }

            public static AlbumModel GetAlbum(int id)
            {
                HttpResponseMessage responseMessage = client.GetAsync("api/albums/" + id).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    var album = responseMessage.Content.ReadAsAsync<AlbumModel>().Result;
                    Console.WriteLine(album);
                    return album;
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)responseMessage.StatusCode, responseMessage.ReasonPhrase);
                    return null;
                }
            }

            public static void Edit(int id, Album album)
            {
                album.AlbumId = id;
                HttpResponseMessage responseMessage = client.PutAsJsonAsync("api/albums/" + id, album).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    Console.WriteLine("Album with id: {0} edited!", id);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)responseMessage.StatusCode, responseMessage.ReasonPhrase);
                }
            }

            public static void Delete(int id)
            {
                HttpResponseMessage responseMessage = client.DeleteAsync("api/albums/" + id).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    Console.WriteLine("Album with id: {0} deleted!", id);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)responseMessage.StatusCode, responseMessage.ReasonPhrase);
                }
            }
        }

        public class Songs
        {
            public static void GetAllSongs()
            {
                HttpResponseMessage response = client.GetAsync("api/songs").Result;
                if (response.IsSuccessStatusCode)
                {
                    var songs = response.Content.ReadAsAsync<IEnumerable<SongModel>>().Result;
                    foreach (var song in songs)
                    {
                        Console.WriteLine(song);
                    }
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }

            public static SongModel GetSong(int id)
            {
                HttpResponseMessage response = client.GetAsync("api/songs/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    var song = response.Content.ReadAsAsync<SongModel>().Result;
                    Console.WriteLine(song);
                    return song;
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                    return null;
                }
            }

            public static Song Add(SongModel song)
            {

                HttpResponseMessage responseMessage = client.PostAsJsonAsync("api/songs", song).Result;
                var mySong = responseMessage.Content.ReadAsAsync<Song>().Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    Console.WriteLine("Song added: {0}", song.Title);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)responseMessage.StatusCode, responseMessage.ReasonPhrase);
                }

                return mySong;
            }

            public static void Edit(int id, Song song)
            {
                song.SongId = id;
                HttpResponseMessage responseMessage = client.PutAsJsonAsync("api/songs/" + id, song).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    Console.WriteLine("Song with id: {0} edited!", id);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)responseMessage.StatusCode, responseMessage.ReasonPhrase);
                }
            }

            public static void Delete(int id)
            {
                HttpResponseMessage responseMessage = client.DeleteAsync("api/songs/" + id).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    Console.WriteLine("Song with id: {0} deleted!", id);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)responseMessage.StatusCode, responseMessage.ReasonPhrase);
                }
            }
        }
    }
}
