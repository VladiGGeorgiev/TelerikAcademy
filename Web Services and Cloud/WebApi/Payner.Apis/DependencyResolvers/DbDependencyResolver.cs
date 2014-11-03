using Payner.Apis.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Payner.Models;
using Payner.Repositories;
using Payner.Data;
using System.Data.Entity;

namespace Payner.Apis.DependencyResolvers
{
    public class DbDependencyResolver : IDependencyResolver
    {
        private static DbContext context = new PaynerContext();
        private static IRepository<Artist> aristRepository = new EfRepository<Artist>(context);
        private static IRepository<Album> albumsRepository = new EfRepository<Album>(context);
        private static IRepository<Song> songRepository = new EfRepository<Song>(context);

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(AlbumsController))
            {
                return new AlbumsController(albumsRepository);
            }
            else if (serviceType == typeof(ArtistsController))
            {
                return new ArtistsController(aristRepository);
            }
            else if (serviceType == typeof(SongsController))
            {
                return new SongsController(songRepository);
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