using Microsoft.AspNet.Identity.EntityFramework;
using PracticalExam.Models;
using System.Data.Entity;

namespace PracticalExam.Data
{
    public class ApplicationDbContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Ticket> Tickets { get; set; }
    }
}
