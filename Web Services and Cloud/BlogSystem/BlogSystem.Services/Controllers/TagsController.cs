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
    public class TagsController : BaseApiController
    {
        private IRepository<Tag> tagsRepository;
        private IRepository<User> usersRepository;
        private IRepository<Post> postsRepository;
        public TagsController(IRepository<Tag> repository, IRepository<User> usersRepository, IRepository<Post> postsRepository)
        {
            this.tagsRepository = repository;
            this.usersRepository = usersRepository;
            this.postsRepository = postsRepository;
        }

        [HttpGet]
        public IEnumerable<TagModel> GetAllTags([ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var getTagsResponse = this.TryToExecuteOperation(() =>
            {
                if (!usersRepository.All().Any(x => x.SessionKey == sessionKey))
                {
                    throw new InvalidOperationException("Not authorized user!");
                }

                var tags = this.tagsRepository.All().ToList().Select(DataMapper.TagToTagModel);
                tags = tags.OrderBy(x => x.Name);
                return tags;
            });

            return getTagsResponse;
        }

        [HttpGet, ActionName("posts")]
        public IEnumerable<PostModel> GetPostsByTag(int id,
                                               [ValueProvider(typeof (HeaderValueProviderFactory<string>))] string
                                                   sessionKey)
        {
            var getPostsByTagResponse = this.TryToExecuteOperation(() =>
            {
                if (!usersRepository.All().Any(x => x.SessionKey == sessionKey))
                {
                    throw new InvalidOperationException("Not authorized user!");
                }

                var posts = this.postsRepository.All().ToList()
                                .Where(x => x.Tags.Any(t => t.TagId == id))
                                .Select(DataMapper.PostToPostModel)
                                .OrderByDescending(x => x.PostDate);
                return posts;
            });

            return getPostsByTagResponse;
        }
    }
}
