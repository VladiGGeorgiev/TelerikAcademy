using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using BlogSystem.Models;
using BlogSystem.Repositories;
using BlogSystem.Services.Attributes;
using BlogSystem.Services.Models;

namespace BlogSystem.Services.Controllers
{
    public class PostsController : BaseApiController
    {
        private IRepository<Post> postsRepository;
        private IRepository<User> usersRepository;
        private IRepository<Tag> tagsRepository;
        private IRepository<Comment> commentsRepository;

        public PostsController(IRepository<Post> postsRepository, IRepository<User> usersRepository, IRepository<Tag> tagsRepository, IRepository<Comment> commentsRepository)
        {
            this.postsRepository = postsRepository;
            this.usersRepository = usersRepository;
            this.tagsRepository = tagsRepository;
            this.commentsRepository = commentsRepository;
        }

        [HttpPost]
        public HttpResponseMessage CreateNewPost(CreatePostModel postModel, [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var createPostResponse = this.TryToExecuteOperation(() =>
            {
                if (!usersRepository.All().Any(x => x.SessionKey == sessionKey))
                {
                    throw new InvalidOperationException("Not authorized user!");
                }
                if (postModel == null)
                {
                    throw new InvalidOperationException("The input model can not be null!");
                }

                if (string.IsNullOrEmpty(postModel.Title) || string.IsNullOrEmpty(postModel.Text))
                {
                    throw new InvalidOperationException("The title and text in post can not be null or empty string!");
                }

                var user = this.usersRepository.All().ToList()
                    .FirstOrDefault(x => x.SessionKey == sessionKey);

                var post = DataMapper.CreatePostModelToPost(postModel);
                post.PostedBy = user;

                var dbTags = this.tagsRepository.All().ToList();
                foreach (var tag in postModel.Tags)
                {
                    var dbTag = dbTags.FirstOrDefault(x => x.Name == tag);
                    if (dbTag != null)
                    {
                        post.Tags.Add(dbTag);
                    }
                    else
                    {
                        post.Tags.Add(new Tag()
                            {
                                Name = tag
                            });
                    }
                }

                var dbPost = this.postsRepository.Add(post);

                var postResponseModel = DataMapper.PostToCreatePostResponseModel(dbPost);

                var response = this.Request.CreateResponse(HttpStatusCode.Created, postResponseModel);
                return response;
            });

            return createPostResponse;
        }
    
        [HttpGet]
        public IEnumerable<PostModel> GetAllPosts([ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var getPostsResponse = this.TryToExecuteOperation(() =>
            {
                if (!usersRepository.All().Any(x => x.SessionKey == sessionKey))
                {
                    throw new InvalidOperationException("Not authorized user!");
                }

                var posts = this.postsRepository.All().ToList().Select(DataMapper.PostToPostModel);
                posts = posts.OrderByDescending(x => x.PostDate);
                return posts;
            });

            return getPostsResponse;
        }

        [HttpGet] //api/posts?page=0&count=2
        public IEnumerable<PostModel> GetPagingPosts(int page, int count, [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var getPostsResponse = this.TryToExecuteOperation(() =>
            {
                if (!usersRepository.All().Any(x => x.SessionKey == sessionKey))
                {
                    throw new InvalidOperationException("Not authorized user!");
                }

                var posts = this.postsRepository.All()
                    .ToList().Skip(page * count).Take(count)
                    .Select(DataMapper.PostToPostModel);
                posts = posts.OrderByDescending(x => x.PostDate);

                return posts;
            });

            return getPostsResponse;
        } 

        [HttpGet] //api/posts?keyword=webapi
        public IEnumerable<PostModel> GetPostsByTitleKeyword(string keyword,
                                                            [ValueProvider(typeof (HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var getPostsResponse = this.TryToExecuteOperation(() =>
            {
                if (!usersRepository.All().Any(x => x.SessionKey == sessionKey))
                {
                    throw new InvalidOperationException("Not authorized user!");
                }

                var posts = this.postsRepository.All().ToList()
                    .Where(x => x.Title.ToLower().Contains(keyword.ToLower()))
                    .Select(DataMapper.PostToPostModel);

                posts = posts.OrderByDescending(x => x.PostDate);

                return posts;
            });

            return getPostsResponse;
        }

        [HttpGet]
        public IEnumerable<PostModel> GetPostsByTags(string tags,
                                                     [ValueProvider(typeof (HeaderValueProviderFactory<string>))] string
                                                         sessionKey)
        {
            var getPostsResponse = this.TryToExecuteOperation(() =>
            {
                if (!usersRepository.All().Any(x => x.SessionKey == sessionKey))
                {
                    throw new InvalidOperationException("Not authorized user!");
                }

                var splitedTags = tags.Split(',').ToList();

                var tagsByPosts = GetAllPosts(sessionKey);
                var posts = tagsByPosts
                    .Where(x => x.Tags.Intersect(splitedTags).Count() == splitedTags.Count);

                return posts;
            });

            return getPostsResponse;
        }

        [HttpPut] //PUT api/posts/{postId}/comment
        public HttpResponseMessage AddCommentToPost(int id, CommentRequestModel commentModel,
                                                    [ValueProvider(typeof (HeaderValueProviderFactory<string>))] string
                                                        sessionKey)
        {
            var addCommentResponse = this.TryToExecuteOperation(() =>
            {
                if (!usersRepository.All().Any(x => x.SessionKey == sessionKey))
                {
                    throw new InvalidOperationException("Not authorized user!");
                }

                if (commentModel == null || string.IsNullOrEmpty(commentModel.Text))
                {
                    throw new InvalidOperationException("The comment or comment text can not be null!");
                }

                var user = this.usersRepository.All().FirstOrDefault(x => x.SessionKey == sessionKey);
                var post = this.postsRepository.Get(id);
                var comment = new Comment()
                    {
                        Text = commentModel.Text,
                        PostDate = DateTime.Now,
                        CommentedBy = user,
                        Post = post
                    };
                this.commentsRepository.Add(comment);

                var response = this.Request.CreateResponse(HttpStatusCode.Created);
                return response;
            });


            return addCommentResponse;
        }
    }
}
