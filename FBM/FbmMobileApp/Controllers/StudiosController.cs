using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using FbmMobileApp.Data;
using FbmMobileApp.Models;
using FbmMobileApp.ViewModels;

namespace FbmMobileApp.Controllers
{
    public class StudiosController : ApiController
    {
        private FbmContext context;

        public StudiosController()
        {
            this.context = new FbmContext();
        }

        public IQueryable<StudioModel> GetStudios()
        {
            var studios = this.context.Studios.Select(studio => new StudioModel()
            {
                Name = studio.Name,
                Town = studio.Town.Name,
                Id = studio.Id,
                Picture = studio.Picture,
                Latitude = studio.Latitude,
                Longitude = studio.Longitude
            }); 


            return studios; 
        }

        [HttpGet]
        public StudioDetailsModel Details(int id)
        {
            var studio = this.context.Studios.FirstOrDefault(s => s.Id == id);
            var comments = this.context.Comments.Where(x => x.StudioId == studio.Id);
            var studioModel = new StudioDetailsModel()
            {
                Name = studio.Name,
                Address = studio.Address,
                Email = studio.Email,
                Facebook = studio.Facebook,
                Latitude = studio.Latitude,
                Longitude = studio.Longitude,
                PhoneNumber = studio.PhoneNumber,
                Picture = studio.Picture,
                Rating = studio.Rating,
                WebSite = studio.WebSite,
                Town = studio.Town.Name,
                Id = studio.Id,
                Comments = comments.Select(x => new CommentModel()
                {
                    Author = x.Author,
                    Content = x.Content,
                    Id = x.Id
                }).ToList()
            };

            return studioModel;
        }

        public IQueryable<Studio> GeStudiosByTown(string town)
        {
            var studios = this.context.Studios.Where(studio => studio.Town.Name == town);
            return studios;
        }

        [HttpPost, ActionName("Comment")]
        public HttpResponseMessage PostComment(PostCommentModel model)
        {
            var studioId = int.Parse(model.Id);
            context.Comments.Add(new Comment()
            {
                Author = model.Author,
                Content = model.Comment,
                StudioId = studioId,
            });
            context.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.Created);
        }
    }
}