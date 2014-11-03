using System.Data.Entity;
using Payner.Models;

namespace Payner.Data
{
    public class PaynerContext : DbContext
    {
        public PaynerContext() : base("Payner")
        {
        }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Song> Songs { get; set; }
    }
}