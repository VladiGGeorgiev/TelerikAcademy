using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AspForum.Models
{
    public class ForumDb : DbContext
    {
        public ForumDb()
            : base("DefaultConnection")
        {
        }

        public DbSet<ForumPost> ForumPosts { get; set; }
        public DbSet<ForumPostAnswer> ForumPostAnswers { get; set; }
    }
}