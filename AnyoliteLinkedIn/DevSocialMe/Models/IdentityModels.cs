using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;

namespace DevSocialMe.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : User
    {
        public ApplicationUser()
        {
            this.Groups = new HashSet<Group>();
            this.Skills = new HashSet<Skill>();
        }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string FullName { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        public string AvatarUrl { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(300)]
        public string Summary { get; set; }

        public virtual ICollection<Group> Groups { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, UserClaim, UserSecret, UserLogin, Role, UserRole, Token, UserManagement>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Vote> Votes { get; set; }
    }
}