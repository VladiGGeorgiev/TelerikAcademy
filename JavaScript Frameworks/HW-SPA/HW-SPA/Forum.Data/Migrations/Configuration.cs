namespace Forum.Data.Migrations
{
    using Forum.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Forum.Data.ForumContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Forum.Data.ForumContext context)
        {
            var user = new User()
            {
                Username = "testuser",
                Nickname = "Test User",
                AuthenticationCode = "f17f143292ba8456570a73b8996f16f7fd8ac810", //123456
            };

            var commentingUser = new User()
            {
                Username = "commentuser",
                Nickname = "Comment User",
                AuthenticationCode = "f17f143292ba8456570a73b8996f16f7fd8ac810", //123456
            };

            var firstPost = new Post()
            {
                Title = "First Post in The Forum",
                Content = "Content of the first post in the forum",
                Creator = user,
                PostDate = DateTime.Now,
                Tags = new HashSet<Tag>() { 
                    new Tag("first"),
                    new Tag("post"),
                    new Tag("in"),
                    new Tag("the"),
                    new Tag("forum"),
                }
            };

            var randomPost = new Post()
            {
                Title = "Random Post",
                Content = "Content of the random post",
                Creator = user,
                PostDate = DateTime.Now,
                Tags = new HashSet<Tag>() { 
                    new Tag("random"),
                    new Tag("post"),
                },
                Comments = new HashSet<Comment>() { 
                    new Comment(){
                        Content="This post is meaningless!!!!",
                        Creator=commentingUser,
                        PostDate = DateTime.Now,
                    }
                }
            };

            user.Posts.Add(firstPost);
            user.Posts.Add(randomPost);

            context.Users.AddOrUpdate(x => x.Username, user);
            context.SaveChanges();


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
