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

namespace BlogSystem.Services.Tests.UsersControllerTests
{
    [TestClass]
    public class CreatePostTests
    {
        private static TransactionScope transaction;
        private InMemoryHttpServer httpServer;

        [TestInitialize]
        public void OpenTransaction()
        {
            transaction = new TransactionScope();

            httpServer = new InMemoryHttpServer("http://localhost/", new EfRepository<User>(new BlogSystemContext()), new HashSet<Route>()
                {
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
        public void TestWithValidPost_ShouldCreatePostInDatabase()
        {
            var testPost = new Post()
                {
                    Title = "Test post",
                    Tags = new List<Tag>() { new Tag()
                        {
                            Name = "technology"
                        },
                       
                },
                    Text = "this is just a test post"
                };

            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };
            LoggedUserModel userModel = RegisterTestUser(httpServer, testUser);

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;

            var response = httpServer.Post("api/posts", testPost, headers);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [TestMethod]
        public void TestWithInvalidPostWithoutTitle_ShouldReturnBadRequest()
        {
            var testPost = new Post()
            {
                Tags = new List<Tag>() { new Tag()
                        {
                            Name = "technology"
                        },
                       
                },
                Text = "this is just a test post"
            };

            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };
            LoggedUserModel userModel = RegisterTestUser(httpServer, testUser);

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;

            var response = httpServer.Post("api/posts", testPost, headers);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void TestWithInvalidPostWithoutText_ShouldReturnBadRequest()
        {
            var testPost = new Post()
            {
                Title = "Test post",
                Tags = new List<Tag>() { new Tag()
                        {
                            Name = "technology"
                        },
                       
                }
            };

            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };
            LoggedUserModel userModel = RegisterTestUser(httpServer, testUser);

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;

            var response = httpServer.Post("api/posts", testPost, headers);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
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
