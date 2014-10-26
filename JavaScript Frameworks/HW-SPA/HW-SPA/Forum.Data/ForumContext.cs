namespace Forum.Data
{
    using Forum.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ForumContext : DbContext
    {
        public ForumContext()
            : base("ForumDatabase")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(x => x.AuthenticationCode).IsFixedLength().HasMaxLength(40);
            modelBuilder.Entity<User>().Property(x => x.SessionKey).IsFixedLength().HasMaxLength(50);

            modelBuilder.Entity<Tag>().Property(x => x.Name).IsUnicode(true);

            modelBuilder.Entity<Post>().Property(x => x.Title).IsUnicode(true);
            modelBuilder.Entity<Post>().Property(x => x.Content).IsUnicode(true);

            modelBuilder.Entity<Comment>().Property(x => x.Content).IsUnicode(true);
            base.OnModelCreating(modelBuilder);
        }
    }
}
