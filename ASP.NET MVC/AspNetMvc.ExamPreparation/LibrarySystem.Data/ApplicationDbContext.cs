using System.Data.Entity;
using LibrarySystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LibrarySystem.Data
{
    public class ApplicationDbContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        public IDbSet<Laptop> Laptops { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Manufacturer> Manufacturers { get; set; }

        public IDbSet<Vote> Votes { get; set; }
    }
}
