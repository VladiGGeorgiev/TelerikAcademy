using System;
using System.Collections.Generic;
using LibrarySystem.Models;

namespace LibrarySystem.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public UnitOfWork()
            : this(new ApplicationDbContext())
        {
        }

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IUsersRepository UsersRepository
        {
            get
            {
                return (UsersRepository)this.GetRepository<ApplicationUser>();
            }
        }

        public IRepository<Laptop> LaptopsRepository
        {
            get
            {
                return this.GetRepository<Laptop>();
            }
        }

        public IRepository<Comment> CommentsRepository
        {
            get
            {
                return this.GetRepository<Comment>();
            }
        }

        public IRepository<Manufacturer> ManufacturersRepository
        {
            get
            {
                return this.GetRepository<Manufacturer>();
            }
        }

        public IRepository<Vote> VotesRepository
        {
            get
            {
                return this.GetRepository<Vote>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                if (typeof(T).IsAssignableFrom(typeof(ApplicationUser)))
                {
                    type = typeof (UsersRepository);
                }

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
