using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using Forum.Model;
using Forum.Repositories;
using Forum.Services.Attributes;
using Forum.Services.Models;

namespace Forum.Services.Controllers
{
    public class ThreadsController : BaseController
    {
        private IRepository<Thread> threadRepository;
        private IRepository<User> usersRepository;
        private IRepository<Post> postsRepository; 

        public ThreadsController(IRepository<Thread> threadRepository, IRepository<User> usersRepository, IRepository<Post> postsRepository)
        {
            this.threadRepository = threadRepository;
            this.usersRepository = usersRepository;
            this.postsRepository = postsRepository;
        }

        [HttpGet]
        public IEnumerable<ThreadDetailModel> GetAllThreads([ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var threadsResponse = this.PerformOperationAndHandleExceptions(() =>
                {
                    if (!usersRepository.All().Any(x => x.SessionKey == sessionKey))
                    {
                        throw new InvalidOperationException("Not authorized user!");
                    }

                    var threads = this.threadRepository.All().ToList().Select(DataMapper.ThreadToThreadDetailModel);

                    return threads;
                });

            return threadsResponse;
        }

        [HttpGet]
        public IEnumerable<ThreadDetailModel> GetThreadsByCategory(string category, [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var threadsResponse = this.PerformOperationAndHandleExceptions(() =>
            {
                if (!usersRepository.All().Any(x => x.SessionKey == sessionKey))
                {
                    throw new InvalidOperationException("Not authorized user!");
                }

                var threads = this.threadRepository.All()
                    .Where(x => x.Categories.Any(c => c.Name == category))
                    .ToList()
                    .Select(DataMapper.ThreadToThreadDetailModel);

                return threads;
            });

            return threadsResponse;
        }

        [HttpGet]//api/threads?page=1&count=2
        public IEnumerable<ThreadDetailModel> GetThreadsManualy(int page, int count, [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var threadsResponse = this.PerformOperationAndHandleExceptions(() =>
            {
                if (!usersRepository.All().Any(x => x.SessionKey == sessionKey))
                {
                    throw new InvalidOperationException("Not authorized user!");
                }

                var threads = this.threadRepository.All()
                    .ToList().Skip(page * count).Take(count)
                    .Select(DataMapper.ThreadToThreadDetailModel);

                return threads;
            });

            return threadsResponse;
        }
 
        [HttpPost]
        public HttpResponseMessage CreateThread([FromBody]ThreadModel threadModel)
        {
            var response = this.PerformOperationAndHandleExceptions(() =>
                {
                    if (threadModel == null)
                    {
                        throw new InvalidOperationException("Thread can not be null!");
                    }

                    var thread = DataMapper.ThreadModelToThread(threadModel);

                    var dbThread = this.threadRepository.Add(thread);

                    var threadResponse = this.Request.CreateResponse(HttpStatusCode.Created, dbThread);
                    return threadResponse;
                });
            return response;
        }

        [HttpGet, ActionName("posts")]
        public IEnumerable<PostModel> GetPostsByThread(int id, [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var threadsResponse = this.PerformOperationAndHandleExceptions(() =>
            {
                if (!usersRepository.All().Any(x => x.SessionKey == sessionKey))
                {
                    throw new InvalidOperationException("Not authorized user!");
                }
                else if (id <= 0)
                {
                    throw new InvalidOperationException("Id must be positive number!");
                }

                var posts = this.postsRepository.All().ToList().Where(x => x.Thread.ThreadId == id).Select(DataMapper.PostToPostModel);

                return posts;
            });

            return threadsResponse;
        } 
    }
}
