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
    public class CategoriesController : ApiController
    {
        private IRepository<Category> repository;

        public CategoriesController(IRepository<Category> repository)
        {
            this.repository = repository;
        }
    }
}
