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
    public class LogoutTests
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
        public void TestWithValidSessionKey_ShouldLogout()
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

            var response = httpServer.Put("api/users/logout", headers);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void TestWithInValidSessionKey_ShouldReturnBadRequest()
        {
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = new string('b', 40);

            var response = httpServer.Put("api/users/logout", headers);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void TestWithoutSessionKeyInHeader_ShouldReturnBadRequest()
        {
            var response = httpServer.Put("api/users/logout");
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void TestWithWrongSessionKeyLength_ShouldReturnBadRequest()
        {
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = new string('b', 10);

            var response = httpServer.Put("api/users/logout", headers);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void TestWithWrongSessionKeyChars_ShouldReturnBadRequest()
        {
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = "!@#$%^&*()_+~";

            var response = httpServer.Put("api/users/logout", headers);
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
