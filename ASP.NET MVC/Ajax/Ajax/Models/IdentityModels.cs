using System.CodeDom;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ajax.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : User
    {  
    }

    public class ApplicationDbContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        public IDbSet<Movie> Movies { get; set; }

        public IDbSet<LeadingRole> LeadingRoles { get; set; }
    }
}