using System;
using System.Collections.Generic;
using System.Transactions;
using System.Web.Http;
using BlogSystem.Data;
using BlogSystem.Models;
using BlogSystem.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace BlogSystem.Services.Tests.UsersControllerTests
{
    [TestClass]
    public class RegisterTests
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
        public void TestValidUser_ShouldAddToDatabase()
        {
            var testUser = new User()
                {
                    Username = "MinkaSv",
                    DisplayName = "Minka Svirkata",
                    AuthCode = new string('*', 40)
                };
            var response = httpServer.Post("api/users/register", testUser);

            Assert.IsNotNull(response);
            Assert.AreEqual(HttpStatusCode.Created ,response.StatusCode, 
                string.Format("User is not created in database! Response status code: {0}", response.StatusCode));
        }

        [TestMethod]
        public void TestInvalidUsernameRequest_ShouldReturnBadRequest()
        {
            var testUser = new User()
            {
                Username = "Mink",
                DisplayName = "Minka Svirkata",
                AuthCode = new string('*', 40)
            };

            var response = httpServer.Post("api/users/register", testUser);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void TestInvalidUsernameWithoutUsernameRequest_ShouldReturnBadRequest()
        {
            var testUser = new User()
            {
                DisplayName = "Minka Svirkata",
                AuthCode = new string('*', 40)
            };

            var response = httpServer.Post("api/users/register", testUser);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void TestWithoutAuthCodeRequest_ShouldReturnBadRequest()
        {
            var testUser = new User()
            {
                Username = "MinkaSv",
                DisplayName = "Minka Svirkata",
            };

            var response = httpServer.Post("api/users/register", testUser);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void TestNullRequestBody_ShouldReturnBadRequest()
        {
            var response = httpServer.Post("api/users/register", null);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void TestWithEmptyUserRequestBody_ShouldReturnBadRequest()
        {
            var response = httpServer.Post("api/users/register", new User());

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void TestWithWrongCharsInUsername_ShouldReturnBadRequest()
        {
            var testUser = new User()
            {
                DisplayName = "Mackata",
                Username = "Min!$@%#$^$&*%(^)&k",
                AuthCode = new string('*', 40)
            };

            var response = httpServer.Post("api/users/register", testUser);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void TestWithWrongCharsInDisplayName_ShouldReturnBadRequest()
        {
            var testUser = new User()
            {
                DisplayName = "Min!$@%#$^$&*%(^)&k",
                Username = "ValidUsername",
                AuthCode = new string('*', 40)
            };

            var response = httpServer.Post("api/users/register", testUser);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void TestWithWrongAuthCodeLength_ShouldReturnBadRequest()
        {
            var testUser = new User()
            {
                DisplayName = "Min!$@%#$^$&*%(^)&k",
                Username = "ValidUsername",
                AuthCode = new string('*', 50)
            };

            var response = httpServer.Post("api/users/register", testUser);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
