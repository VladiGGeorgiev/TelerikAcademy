using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Twitter.Models;

namespace Twitter.Data
{
    public class DataContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        public IDbSet<Tweet> Tweets { get; set; }

        public IDbSet<HashTag> HashTags { get; set; } 

        //public IDbSet<ApplicationUser> TwitterUsers { get; set; } 
    }
}
