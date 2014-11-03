using BlogSystem.Data;
using BlogSystem.Models;
using BlogSystem.Repositories;
using BlogSystem.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using System.Data.Entity;

namespace Payner.Apis.DependencyResolvers
{
    public class DbDependencyResolver : IDependencyResolver
    {
        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(UsersController))
            {
                var context = new BlogSystemContext();
                var repository = new EfRepository<User>(context);
                return new UsersController(repository);
            }
            else if (serviceType == typeof(PostsController))
            {
                var context = new BlogSystemContext();
                var postsRepository = new EfRepository<Post>(context);
                var usersRepository = new EfRepository<User>(context);
                var tagsRepository = new EfRepository<Tag>(context);
                var commentsRepository = new EfRepository<Comment>(context);
                return new PostsController(postsRepository, usersRepository, tagsRepository, commentsRepository);
            }
            else if (serviceType == typeof(TagsController))
            {
                var context = new BlogSystemContext();
                var tagsRepository = new EfRepository<Tag>(context);
                var usersRepository = new EfRepository<User>(context);
                var postsRepository = new EfRepository<Post>(context);
                return new TagsController(tagsRepository, usersRepository, postsRepository);
            }
            else
            {
                return null;
            }
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