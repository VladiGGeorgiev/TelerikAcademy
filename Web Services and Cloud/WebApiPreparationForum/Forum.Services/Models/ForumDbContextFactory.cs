using System.Data.Entity.Infrastructure;
using Forum.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Services.Models
{
    public class ForumDbContextFactory : IDbContextFactory<ForumContext>
    {
        public ForumContext Create()
        {
            return new ForumContext();
        }
    }
}
