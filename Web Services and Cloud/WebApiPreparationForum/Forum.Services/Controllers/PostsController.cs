using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Forum.Model;
using Forum.Repositories;

namespace Forum.Services.Controllers
{
    public class PostsController : ApiController
    {
        private IRepository<Post> repository;

        public PostsController(IRepository<Post> repository)
        {
            this.repository = repository;
        }
    }
}
