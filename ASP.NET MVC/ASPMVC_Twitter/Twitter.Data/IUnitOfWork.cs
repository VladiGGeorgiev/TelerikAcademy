using System;
using Twitter.Models;

namespace Twitter.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Tweet> Tweets { get; }

        IRepository<HashTag> HashTags { get; }

        IRepository<ApplicationUser> Users { get; }

        int SaveChanges();
    }
}
