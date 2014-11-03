using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSystem.Models;

namespace BlogSystem.Data
{
    public class BlogSystemContext : DbContext
    {
        public BlogSystemContext()
            : base("BlogSystemDb")
        {
            
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Tag> Tags { get; set; }
    }
}
