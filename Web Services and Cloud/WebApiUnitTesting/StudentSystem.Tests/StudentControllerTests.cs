using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentSystem.Data;
using StudentSystem.Models;
using StudentSystem.Repositories;
using StudentSystem.Services.Controllers;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace StudentSystem.Tests
{
    [TestClass]
    public class StudentControllerTests
    {
        private StudentSystemContext context = new StudentSystemContext();
        private IRepository<Student> studentRepository;
        private IRepository<Mark> markRepository;
        private IRepository<School> schoolRepository;
        private StudentsController controller;

        public StudentControllerTests()
        {
            studentRepository = new EfRepository<Student>(context);
            markRepository = new EfRepository<Mark>(context);
            schoolRepository = new EfRepository<School>(context);
            controller = new StudentsController(studentRepository, schoolRepository, markRepository);
        }

        
        private void SetupController(ApiController controller)
        {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/categories");
            var route = config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            var routeData = new HttpRouteData(route);
            routeData.Values.Add("id", RouteParameter.Optional);
            routeData.Values.Add("controller", "categories");
            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            controller.Request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;
        }

        [TestMethod]
        public void TestAddStudent()
        {
            var studentModel = new Student()
                {
                    FirstName = "Minka",
                    LastName = "Gogova"
                };

            var student = new Student()
            {
                StudentId = 1,
                FirstName = "Pesho Ribata",
                Age = 18
            };

            FakeRepository<Student> repository = new FakeRepository<Student>();
            
        }

        [TestMethod]
        public void Add_WhenNameIsValid_ShouldAddTheCategory()
        {
            bool isItemAdded = false;
            var repository = Mock.Create<IRepository<Student>>();

            var studentModel = new Student()
            {
                FirstName = "NEW TEST NAME"
            };
            var studentEntity = new Student()
            {
                StudentId = 1,
                FirstName = studentModel.FirstName
            };
            Mock.Arrange(() => repository.Add(Arg.IsAny<Student>()))
                .DoInstead(() => isItemAdded = true)
                .Returns(studentEntity);

            var controller = new StudentsController(repository);
            SetupController(controller);

            controller.PostStudent(studentModel);

            Assert.IsTrue(isItemAdded);
        }

        [TestMethod]
        public void GetAll_WhenASingleCategoryInRepository_ShouldReturnSingleCategory()
        {
            var repository = Mock.Create<IRepository<Student>>();
            var studentToAdd = new Student()
            {
                FirstName = "Test category"
            };
            IList<Student> categoryEntities = new List<Student>();
            categoryEntities.Add(studentToAdd);
            Mock.Arrange(() => repository.All()).Returns(() => categoryEntities.AsQueryable());

            var controller = new StudentsController(repository);

            var categoryModels = controller.GetStudents();
            Assert.IsTrue(categoryModels.Count() == 1);
            Assert.AreEqual(studentToAdd.FirstName, categoryModels.First().FirstName);
        }

        [TestMethod]
        public void GetAllCategories_WhenASingleCategoryInRepository_ShouldReturnSingleCategory()
        {
            var repository = new FakeRepository<Student>();

            var studentToAdd = new Student()
            {
                FirstName = "Test category"
            };
            repository.Add(studentToAdd);

            var controller = new StudentsController(repository);

            var categoriesModels = controller.GetStudents();
            Assert.IsTrue(categoriesModels.Count() == 1);
            Assert.AreEqual(studentToAdd.FirstName, categoriesModels.First().FirstName);
        }
    }
}
