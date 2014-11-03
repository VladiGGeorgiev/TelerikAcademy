using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Payner.Apis.Models;
using Payner.Models;
using Payner.Data;
using Payner.Repositories;

namespace Payner.Apis.Controllers
{
    public class SongsController : ApiController
    {
        private readonly IRepository<Song> repository;

        public SongsController()
            : this(new EfRepository<Song>(new PaynerContext()))
        {
        }

        public SongsController(IRepository<Song> repository)
        {
            this.repository = repository;
        }

        // GET api/Songs
        public IEnumerable<SongModel> GetSongs()
        {
            return this.repository.All().Select(SongModel.FromSong);
        }

        // GET api/Songs/5
        public SongModel GetSong(int id)
        {
            SongModel song = this.repository.All()
                .Where(x => x.SongId == id)
                .Select(SongModel.FromSong)
                .FirstOrDefault();

            if (song == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return song;
        }

        // PUT api/Songs/5
        public HttpResponseMessage PutSong(int id, Song song)
        {
            Song dbSong = DataMapper.CreateOrLoadSong(repository, song);
            song.Update(dbSong);

            repository.Update(id, dbSong);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Songs
        public HttpResponseMessage PostSong(SongModel song)
        {
            if (song == null)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Song should be not null!");
                return errResponse;
            }

            Song songToAdd = song.ToSong();
            var entity = this.repository.Add(songToAdd);

            var response = this.Request.CreateResponse(HttpStatusCode.Created, entity);
            response.Headers.Location = new Uri(this.Request.RequestUri + song.SongId.ToString(CultureInfo.InvariantCulture));
            return response;
        }

        // DELETE api/Songs/5
        public HttpResponseMessage DeleteSong(int id)
        {
            repository.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}