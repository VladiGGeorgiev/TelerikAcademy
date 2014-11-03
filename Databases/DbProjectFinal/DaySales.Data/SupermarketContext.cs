using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Supermarket.Model;
using Telerik.OpenAccess;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.Data
{
    public class SupermarketContext : DbContext
    {
        public SupermarketContext()
            : base("Supermarket")
        {
        }

        public DbSet<DailyReport> DailyReports { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Measure> Measurments { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<Expense> Expenses { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vendor>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Measure>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Product>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            //modelBuilder.Entity<DailyReport>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);


            //// modelBuilder.Entity<Tag>().Property(x => x.Text).IsFixedLength();

            //// modelBuilder.Configurations.Add(new TagMappings());

            base.OnModelCreating(modelBuilder);

        }
    }
}