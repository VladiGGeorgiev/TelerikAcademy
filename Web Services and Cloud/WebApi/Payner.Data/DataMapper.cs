using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payner.Repositories;
using Payner.Models;

namespace Payner.Data
{
    public static class DataMapper
    {
        public static Album CreateOrLoadAlbum(IRepository<Album> repository, Album entity)
        {
            Album album = repository.Get(entity.AlbumId);
            if (album != null)
            {
                return album;
            }

            Album newAlbum = repository.Add(new Album()
                {
                    Title = entity.Title,
                    Producer = entity.Producer,
                    Year = entity.Year,
                    Artists = entity.Artists,
                    Songs = entity.Songs
                });

            return newAlbum;
        }

        public static Artist CreateOrLoadArtist(IRepository<Artist> repository, Artist entity)
        {
            Artist artist = repository.Get(entity.ArtistId);
            if (artist != null)
            {
                return artist;
            }

            Artist newArtist = repository.Add(new Artist()
            {
                Name = entity.Name,
                Country = entity.Country,
                DateOfBirth = entity.DateOfBirth,
                Songs = entity.Songs,
                Albums = entity.Albums
            });

            return newArtist;
        }

        public static Song CreateOrLoadSong(IRepository<Song> repository, Song entity)
        {
            Song song = repository.Get(entity.SongId);
            if (song != null)
            {
                return song;
            }

            Song newSong = repository.Add(new Song()
            {
                Title = entity.Title,
                Year = entity.Year,
                Genre = entity.Genre,
                Album = entity.Album,
                Artist = entity.Artist
            });

            return newSong;
        } 
    }
}
