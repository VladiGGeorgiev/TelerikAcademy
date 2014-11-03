using Forum.Model;
using Forum.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using System.Data.Entity;
using Forum.Services.Controllers;
using Forum.Data;

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
            if (serviceType == typeof(CategoriesController))
            {
                var context = new ForumContext();
                var repository = new EfRepository<Category>(context);
                return new CategoriesController(repository);
            }
            else if (serviceType == typeof(PostsController))
            {
                var context = new ForumContext();
                var repository = new EfRepository<Post>(context);
                return new PostsController(repository);
            }
            else if (serviceType == typeof(ThreadsController))
            {
                var context = new ForumContext();
                var threadRepository = new EfRepository<Thread>(context);
                var usersRepository = new EfRepository<User>(context);
                var postsRepository = new EfRepository<Post>(context);
                return new ThreadsController(threadRepository, usersRepository, postsRepository);
            }
            else if (serviceType == typeof(UsersController))
            {
                var context = new ForumContext();
                var repository = new EfRepository<User>(context);
                return new UsersController(repository);
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