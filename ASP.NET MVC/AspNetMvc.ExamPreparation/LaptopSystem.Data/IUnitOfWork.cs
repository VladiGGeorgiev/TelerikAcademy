using LaptopSystem.Models;

namespace LaptopSystem.Data
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        IUsersRepository UsersRepository { get; }

        IRepository<Laptop> LaptopsRepository { get; }

        IRepository<Comment> CommentsRepository { get; }

        IRepository<Manufacturer> ManufacturersRepository { get; }

        IRepository<Vote> VotesRepository { get; } 

        int SaveChanges();
    }
}
