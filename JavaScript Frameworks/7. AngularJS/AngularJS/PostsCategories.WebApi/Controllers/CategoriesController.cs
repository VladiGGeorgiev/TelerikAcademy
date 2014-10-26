using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using PostsCategories.DataLayer;
using PostsCategories.Models;
using PostsCategories.WebApi.Models;

namespace PostsCategories.WebApi.Controllers
{
    public class CategoriesController : ApiController
    {
        public IEnumerable<CategoryModel> GetAll()
        {
            PostsCategoriesContext context = new PostsCategoriesContext();

            return context.Categories.Select(CategoryModel.FromCategory);
        }

        public CategoryFullModel GetAllPosts(int categoryId)
        {
            PostsCategoriesContext context = new PostsCategoriesContext();

            var categoryInfo = context.Categories
                .Where(x => x.Id == categoryId)
                .Select(CategoryFullModel.FromCategory)
                .FirstOrDefault();

            return categoryInfo;
        }
    }
}