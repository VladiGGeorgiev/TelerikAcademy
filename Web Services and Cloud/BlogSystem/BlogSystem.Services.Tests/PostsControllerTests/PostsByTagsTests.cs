using System;
using System.Collections.Generic;
using System.Net;
using System.Transactions;
using System.Web.Http;
using BlogSystem.Data;
using BlogSystem.Models;
using BlogSystem.Repositories;
using BlogSystem.Services.Models;
using Forum.Services.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace BlogSystem.Services.Tests.PostsControllerTests
{
    [TestClass]
    public class PostsByTagsTests
    {
        private static TransactionScope transaction;
        private InMemoryHttpServer httpServer;

        [TestInitialize]
        public void OpenTransaction()
        {
            transaction = new TransactionScope();

            httpServer = new InMemoryHttpServer("http://localhost/", new EfRepository<User>(new BlogSystemContext()), new HashSet<Route>()
                {
                    new Route("PostByTagApi", "api/tags/{id}/{action}", new { controller = "tags" }),
                    new Route("CommentApi", "api/posts/{id}/comment", new { controller = "posts" }),
                    new Route("UsersApi", "api/users/{action}", new { controller = "users" }),
                    new Route("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional }),
                });
        }

        [TestCleanup]
        public void CloseTransaction()
        {
            transaction.Dispose();
        }

        [TestMethod]
        public void TestGetPostsByValidTags_ShoudReturnValidPosts()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };
            LoggedUserModel userModel = RegisterTestUser(httpServer, testUser);
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;

            var testPost = new Post()
            {
                Title = "Test post",
                Tags = new List<Tag>() { new Tag()
                        {
                            Name = "technology"
                        },
                       new Tag()
                        {
                            Name = "it"
                        },
                },
                Text = "this is just a test post"
            };

            httpServer.Post("api/posts", testPost, headers);

            var response = httpServer.Get("api/posts?tags=technology,it", headers);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void TestGetPostsByMissingTags_ShoudReturnValidPosts()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };
            LoggedUserModel userModel = RegisterTestUser(httpServer, testUser);
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;

            var testPost = new Post()
            {
                Title = "Test post",
                Tags = new List<Tag>() { new Tag()
                        {
                            Name = "technology"
                        },
                       new Tag()
                        {
                            Name = "it"
                        },
                },
                Text = "this is just a test post"
            };

            httpServer.Post("api/posts", testPost, headers);

            var response = httpServer.Get("api/posts?tags=wrongtag,wrongags", headers);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            Assert.AreEqual("[]", responseContent);
        }

        private LoggedUserModel RegisterTestUser(InMemoryHttpServer httpServer, UserModel testUser)
        {
            var response = httpServer.Post("api/users/register", testUser);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);
            return userModel;
        }
    }
}
