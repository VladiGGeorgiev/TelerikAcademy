using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using BlogSystem.Data;
using BlogSystem.Models;
using BlogSystem.Repositories;
using BlogSystem.Services.Controllers;

namespace BlogSystem.Services.Tests
{
    class TestPlacesDependencyResolver : IDependencyResolver
    {
        private IRepository<User> usersRepository;
        private IRepository<Post> postsRepository;
        private IRepository<Comment> commentsRepository;
        private IRepository<Tag> tagsRepository; 

        public IRepository<User> UsersRepository
        {
            get
            {
                return this.usersRepository;
            }
            set
            {
                this.usersRepository = value;
            }
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(UsersController))
            {
                return new UsersController(this.UsersRepository as IRepository<User>);
            }
            else if (serviceType == typeof(PostsController))
            {
                var context = new BlogSystemContext();
                this.postsRepository = new EfRepository<Post>(context);
                this.usersRepository = new EfRepository<User>(context);
                this.tagsRepository = new EfRepository<Tag>(context);
                return new PostsController(postsRepository, usersRepository, tagsRepository, commentsRepository);
            }

            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {

        }
    }
}
