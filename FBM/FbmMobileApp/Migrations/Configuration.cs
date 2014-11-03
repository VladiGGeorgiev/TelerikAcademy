using FbmMobileApp.Models;

namespace FbmMobileApp.Migrations
{
    using FbmMobileApp.Data;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<FbmContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(FbmContext context)
        {
            var sofiaTown = new Town()
            {
                Name = "Sofia"
            };
            context.Towns.Add(sofiaTown);
            for (int i = 0; i < 10; i++)
            {
                var studio = new Studio()
                {
                    Name = "Studio " + i,
                    Address = "Address " + i,
                    Email = "Email@" + i,
                    Facebook = "Facebook " + i,
                    Latitude = i + i,
                    Longitude = i*3,
                    PhoneNumber = "423423423",
                    Picture = "dasdasd",
                    Rating = i,
                    WebSite = "http://site" + i + ".com",
                };
                for (int j = 0; j < 10; j++)
                {
                    studio.Comments.Add(new Comment()
                    {
                        Content = "Contentj" + j * i * 3,
                        Author = "Author" + j
                    });
                }

                sofiaTown.Studios.Add(studio);
            }

            var varnaTown = new Town()
            {
                Name = "Varna"
            };
            context.Towns.Add(sofiaTown);
            for (int i = 0; i < 10; i++)
            {
                var studio = new Studio()
                {
                    Name = "Studio " + i,
                    Address = "Address " + i,
                    Email = "Email@" + i,
                    Facebook = "Facebook " + i,
                    Latitude = i + i,
                    Longitude = i * 3,
                    PhoneNumber = "423423423",
                    Picture = "dasdasd",
                    Rating = i,
                    WebSite = "http://site" + i + ".com",

                };
                for (int j = 0; j < 10; j++)
                {
                    studio.Comments.Add(new Comment()
                    {
                        Content = "Contentj" + j * i * 3,
                        Author = "Author" + j
                    });
                }
                sofiaTown.Studios.Add(studio);
            }

            context.SaveChanges();
        }
    }
}
