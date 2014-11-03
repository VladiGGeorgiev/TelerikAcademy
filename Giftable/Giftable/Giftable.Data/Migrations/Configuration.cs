using System.Collections.ObjectModel;
using Giftable.Models;

namespace Giftable.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Giftable.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Giftable.Data.ApplicationDbContext context)
        {
            if (context.Users.Count() > 1)
                return;

            context.Users.Add(new User()
            {
                AccessToken = "1ROCFvewrlaAVGhYVuqAOjMwauNmzaJzEvLicnRXhCcXQFwCNN",
                AuthenticationCode = "",
                Username = "username1",
                Email = "none@none.no",
                Wishlist = new Collection<Gift>()
                        {
                            new Gift()
                                {
                                    Image = "https://www.lakewood-center.org/files/Christmas-Present-red.jpg",
                                    Name = "gift name",
                                    Description = "gift deacription"
                                }
                        }
            });
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
