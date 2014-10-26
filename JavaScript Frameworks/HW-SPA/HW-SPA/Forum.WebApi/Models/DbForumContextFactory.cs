namespace Forum.WebApi.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using Forum.Data;

    public class DbForumContextFactory : IDbContextFactory<DbContext>
    {
        public DbContext Create()
        {
            return new ForumContext();
        }
    }
}