using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PostsCategories.DataLayer;
using PostsCategories.Models;
using PostsCategories.WebApi.Models;

namespace PostsCategories.WebApi.Controllers
{
    public class PostsController : ApiController
    {
        public IEnumerable<PostModel> GetAll()
        {
            PostsCategoriesContext context = new PostsCategoriesContext();

            var posts = context.Posts.Select(PostModel.FromPost);

            return posts;
        }

        public PostModel GetPost(int postId)
        {
            PostsCategoriesContext context = new PostsCategoriesContext();

            var post = context.Posts
                .Where(x => x.Id == postId)
                .Select(PostModel.FromPost)
                .FirstOrDefault();

            return post;
        }

        public PostModel PostPost([FromBody] PostModel postDetails)
        {
            PostsCategoriesContext context = new PostsCategoriesContext();

            if (postDetails == null || postDetails.Category == null || postDetails.Category.Name == null
                || postDetails.Category.Name.Length <= 1)
            {
                throw new ArgumentOutOfRangeException("Invalid post data.");
            }

            var category = context.Categories
                .FirstOrDefault(x => x.Name.ToLower() == postDetails.Category.Name.ToLower());

            if (category == null)
            {
                category = new Category
                {
                    Name = postDetails.Category.Name.ToLower()
                };

                context.Categories.Add(category);
                context.SaveChanges();
            }

            Post newPost = new Post
            {
                Title = postDetails.Title,
                Content = postDetails.Content,
                Category = category
            };

            context.Posts.Add(newPost);
            context.SaveChanges();


            return context.Posts
                .Where(x => x.Id == newPost.Id)
                .Select(PostModel.FromPost)
                .FirstOrDefault();
        }
    }
}
