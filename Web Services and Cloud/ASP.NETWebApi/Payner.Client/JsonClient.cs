using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Payner.Models;

namespace Payner.Client
{
    public static class JsonClient
    {
        private static HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:36313/") };

        static JsonClient()
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static class Artists
        {
            public static void AddArtist(string name, string country, DateTime dateOfBirth)
            {
                Artist newArtist = new Artist { Name = name, Country = country, DateOfBirth = dateOfBirth };
                var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("name", name),
                        new KeyValuePair<string, string>("country", country),
                        new KeyValuePair<string, string>("DateOfBirth", dateOfBirth.ToShortDateString()),
                    });
                HttpResponseMessage response = client.PostAsync("api/artist", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Artist added: {0}", newArtist.Name);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }

            public static void DeleteArtist(int id)
            {
                HttpResponseMessage response = client.DeleteAsync("api/artist/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Artist with id: {0} deleted", id);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }

            public static void ShowAllArtists()
            {
                HttpResponseMessage response = client.GetAsync("api/artist").Result;

                if (response.IsSuccessStatusCode)
                {
                    var artists = response.Content.ReadAsAsync<IEnumerable<Artist>>().Result;
                    foreach (var artist in artists)
                    {
                        Console.WriteLine("ArtistId: {0}, Name: {1}, Country: {2}, Birth: {3}",
                                          artist.ArtistId, artist.Name, artist.Country, artist.DateOfBirth);
                    }
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }

            public static Artist GetArtist(int id)
            {
                HttpResponseMessage response = client.GetAsync("api/artist/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    var artist = response.Content.ReadAsAsync<Artist>().Result;
                    Console.WriteLine("ArtistId: {0}, Name: {1}, Country: {2}, Birth: {3}",
                                      artist.ArtistId, artist.Name, artist.Country, artist.DateOfBirth);
                    return artist;
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                    return null;
                }
            }

            public static void EditArtist(int id, string name, string country, DateTime dateOfBirth)
            {
                Artist newArtist = new Artist { ArtistId = id, Name = name, Country = country, DateOfBirth = dateOfBirth };
                var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("name", name),
                        new KeyValuePair<string, string>("country", country),
                        new KeyValuePair<string, string>("DateOfBirth", dateOfBirth.ToShortDateString()),
                    });

                HttpResponseMessage response = client.PutAsJsonAsync("api/artist/" + id, newArtist).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Artist edited: {0}", newArtist.Name);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
        }

        public class Albums
        {
            public static void Add(string title, string producer, DateTime year, ICollection<Artist> artists,
                                   ICollection<Song> songs)
            {
                Album newAlbum = new Album
                    {
                        Title = title,
                        Year = year,
                        Artists = artists,
                        Songs = songs,
                        Producer = producer
                    };
                HttpResponseMessage responseMessage = client.PostAsJsonAsync("api/album", newAlbum).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    Console.WriteLine("Album added: {0}", newAlbum.Title);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)responseMessage.StatusCode, responseMessage.ReasonPhrase);
                }
            }

            public static void GetAllAlbums()
            {
                HttpResponseMessage responseMessage = client.GetAsync("api/album").Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    var albums = responseMessage.Content.ReadAsAsync<IEnumerable<Album>>().Result;
                    foreach (var album in albums)
                    {
                        Console.WriteLine("Album: {0}, id: {1}, Producer: {2}, Year: {3}", album.Title, album.AlbumId, album.Producer, album.Year);
                    }
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)responseMessage.StatusCode, responseMessage.ReasonPhrase);
                }
            }

            public static void GetAlbum(int id)
            {
                HttpResponseMessage responseMessage = client.GetAsync("api/albul/" + id).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    var album = responseMessage.Content.ReadAsAsync<Album>().Result;
                    Console.WriteLine("Album: {0}, id: {1}, Producer: {2}, Year: {3}", album.Title, album.AlbumId, album.Producer, album.Year);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)responseMessage.StatusCode, responseMessage.ReasonPhrase);
                }
            }

            public static void Edit(int id, Album album)
            {
                album.AlbumId = id;
                HttpResponseMessage responseMessage = client.PutAsJsonAsync("api/album/" + id, album).Result;

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
                HttpResponseMessage responseMessage = client.DeleteAsync("api/album/" + id).Result;

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
                HttpResponseMessage response = client.GetAsync("api/song").Result;
                if (response.IsSuccessStatusCode)
                {
                    var songs = response.Content.ReadAsAsync<IEnumerable<Song>>().Result;
                    foreach (var song in songs)
                    {
                        Console.WriteLine("Song: {0}, id: {1}, Artist: {2}, Genre: {3}, Year: {4}", song.Title, song.SongId, song.Artist.Name, song.Genre, song.Year);
                    }
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }

            public static Song GetSong(int id)
            {
                HttpResponseMessage response = client.GetAsync("api/song/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    var song = response.Content.ReadAsAsync<Song>().Result;
                    Console.WriteLine("Song: {0}, id: {1}, Artist: {2}, Genre: {3}, Year: {4}", song.Title, song.SongId, song.Artist, song.Genre, song.Year);
                    return song;
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                    return null;
                }
            }

            public static void Add(Song song)
            {
                Song newSong = new Song { Artist = song.Artist, Genre = song.Genre, Title = song.Title, Year = song.Year };
                HttpResponseMessage responseMessage = client.PostAsJsonAsync("api/song", newSong).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    Console.WriteLine("Song added: {0}", newSong.Title);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)responseMessage.StatusCode, responseMessage.ReasonPhrase);
                }
            }

            public static void Delete(int id)
            {
                HttpResponseMessage responseMessage = client.DeleteAsync("api/song/" + id).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    Console.WriteLine("Song with id: {0} deleted!", id);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)responseMessage.StatusCode, responseMessage.ReasonPhrase);
                }
            }

            public static void Edit(int id, Song song)
            {
                song.SongId = id;
                HttpResponseMessage responseMessage = client.PutAsJsonAsync("api/song/" + id, song).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    Console.WriteLine("Song with id: {0} edited!", id);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)responseMessage.StatusCode, responseMessage.ReasonPhrase);
                }
            }
        }
    }
}
