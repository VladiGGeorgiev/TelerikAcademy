using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Payner.Apis.Models;
using Payner.Models;
using Payner.Data;
using Payner.Repositories;

namespace Payner.Apis.Controllers
{
    public class ArtistsController : ApiController
    {
        private IRepository<Artist> repository;

        public ArtistsController()
            : this(new EfRepository<Artist>(new PaynerContext()))
        {
        }

        public ArtistsController(IRepository<Artist> repository)
        {
            this.repository = repository;
        }

        // GET api/Artists
        public IEnumerable<ArtistModel> GetArtists()
        {
            var artists = this.repository.All().Select(ArtistModel.FromArtist);
            return artists;
        }

        // GET api/Artists/5
        public ArtistModel GetArtist(int id)
        {
            ArtistModel artist = repository.All()
                .Where(x => x.ArtistId == id)
                .Select(ArtistModel.FromArtist).FirstOrDefault();

            if (artist == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return artist;
        }

        // PUT api/Artists/5
        public HttpResponseMessage PutArtist(int id, Artist artist)
        {
            Artist dbArtist = DataMapper.CreateOrLoadArtist(repository, artist);
            artist.Update(dbArtist);
            repository.Update(id, dbArtist);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Artists
        public HttpResponseMessage PostArtist(ArtistModel artist)
        {
            if (artist == null)
            {
                var errResponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error!");
                return errResponse;
            }

            Artist artistToAdd = artist.ToArtist();
            var entity = this.repository.Add(artistToAdd);

            var response = this.Request.CreateResponse(HttpStatusCode.Created, entity);
            response.Headers.Location =
                new Uri(this.Request.RequestUri + artist.ArtistId.ToString(CultureInfo.InvariantCulture));
            return response;
        }

        // DELETE api/Artists/5
        public HttpResponseMessage DeleteArtist(int id)
        {
            this.repository.Delete(id);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}