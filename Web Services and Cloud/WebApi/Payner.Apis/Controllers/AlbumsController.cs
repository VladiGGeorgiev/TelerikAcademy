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
using Payner.Models;
using Payner.Data;
using Payner.Apis.Models;
using Payner.Repositories;

namespace Payner.Apis.Controllers
{
    public class AlbumsController : ApiController
    {
        private IRepository<Album> repository;

        public AlbumsController()
            : this(new EfRepository<Album>(new PaynerContext()))
        {
            repository = new EfRepository<Album>(new PaynerContext());
        }

        public AlbumsController(IRepository<Album> repository)
        {
            this.repository = repository;
        }

        // GET api/Albums
        [HttpGet]
        public IEnumerable<AlbumModel> GetAlbums()
        {
            var albums = repository.All().Select(AlbumModel.FromAlbum);
            return albums;
        }

        // GET api/Albums/5
        [HttpGet]
        public AlbumModel GetAlbum(int id)
        {
            AlbumModel album = repository.All().Where(x => x.AlbumId == id).Select(AlbumModel.FromAlbum).FirstOrDefault();
            if (album == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return album;
        }

        // PUT api/Albums/5
        public HttpResponseMessage PutAlbum(int id, Album album)
        {
            Album dbAlbum = DataMapper.CreateOrLoadAlbum(repository, album);
            album.Update(dbAlbum);
            
            repository.Update(id, dbAlbum);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Albums
        public HttpResponseMessage PostAlbum(AlbumModel album)
        {
            if (album == null)
            {
                var errResponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error!");
                return errResponse;
            }

            Album albumToAdd = album.ToAlbum();
            var entity = this.repository.Add(albumToAdd);

            var response = this.Request.CreateResponse(HttpStatusCode.Created, entity);
            response.Headers.Location = new Uri(this.Request.RequestUri + album.AlbumId.ToString(CultureInfo.InvariantCulture));
            return response;
        }

        // DELETE api/Albums/5
        public HttpResponseMessage DeleteAlbum(int id)
        {
            repository.Delete(id);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}