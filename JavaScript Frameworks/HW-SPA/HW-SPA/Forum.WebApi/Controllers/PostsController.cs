namespace Forum.WebApi.Controllers
{
    using Forum.Models;
    using Forum.WebApi.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.ValueProviders;
    using Forum.WebApi.Attributes;
    using Forum.WebApi.Controllers;

    public class PostsController : BaseApiController
    {
        private readonly IDbContextFactory<DbContext> contextFactory;

        public PostsController()
        {
            this.contextFactory = new DbForumContextFactory();
        }

        public PostsController(IDbContextFactory<DbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        [HttpGet]
        public IQueryable<PostDetails> AllPosts([ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(() =>
                {
                    this.ValidateSessionKey(sessionKey);

                    var context = this.contextFactory.Create();

                    var user = context.Set<User>().Where(x => x.SessionKey == sessionKey).FirstOrDefault();

                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid session key authentication!");
                    }

                    var allPosts = context.Set<Post>().Select(PostDetails.FromPost).OrderByDescending(x => x.PostDate);
                    return allPosts;
                });

            return responseMessage;
        }

        [HttpGet]
        public PostDetails AllPosts(int id,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(() =>
                {
                    this.ValidateSessionKey(sessionKey);

                    if (id < 0)
                    {
                        throw new ArgumentOutOfRangeException("ID cannot be a negative value!");
                    }

                    var context = contextFactory.Create();
                    var user = context.Set<User>().Where(x => x.SessionKey == sessionKey).FirstOrDefault();

                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid session key authentication!");
                    }

                    using (context)
                    {
                        var post = context.Set<Post>().Where(x => x.Id == id).Select(PostDetails.FromPost).FirstOrDefault();
                        return post;
                    }
                });

            return responseMessage;
        }

        [HttpGet]
        public IQueryable<PostDetails> SearchByTags(string tags,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(() =>
            {
                var allTags = tags.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                var allPosts = this.AllPosts(sessionKey).Where(x => !allTags.Except(x.Tags).Any());

                return allPosts;
            });

            return responseMessage;
        }

        [HttpPut]
        [ActionName("comment")]
        public HttpResponseMessage LeaveComment(int postId, [FromBody] CommentModel commentModel,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(() =>
            {
                this.ValidateSessionKey(sessionKey);

                if (postId < 0)
                {
                    throw new ArgumentOutOfRangeException("Post ID must be a positive inreger number!");
                }

                var context = this.contextFactory.Create();

                using (context)
                {
                    var user = context.Set<User>().Where(x => x.SessionKey == sessionKey).FirstOrDefault();

                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid session key authentication!");
                    }

                    var post = context.Set<Post>().Where(x => x.Id == postId).FirstOrDefault();

                    if (post == null)
                    {
                        throw new InvalidOperationException("Invalid post ID!");
                    }

                    Comment commentToAdd = new Comment()
                    {
                        Content = commentModel.Content,
                        PostDate = DateTime.Now,
                        Post = post,
                        Creator = user
                    };

                    context.Set<Comment>().Add(commentToAdd);
                    context.SaveChanges();

                    var response = this.Request.CreateResponse(HttpStatusCode.OK, "Comment added!");
                    return response;
                }
            });

            return responseMessage;
        }
    }
}
