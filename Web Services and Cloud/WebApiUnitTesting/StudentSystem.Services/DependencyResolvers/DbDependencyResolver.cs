using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using System.Data.Entity;
using StudentSystem.Data;
using StudentSystem.Models;
using StudentSystem.Repositories;
using StudentSystem.Services.Controllers;

namespace StudentSystem.Services.DependencyResolvers
{
    public class DbDependencyResolver : IDependencyResolver
    {

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(StudentsController))
            {
                DbContext context = new StudentSystemContext();
                var studentRepository = new EfRepository<Student>(context);
                var schoolRepository = new EfRepository<School>(context);
                var markRepository = new EfRepository<Mark>(context);
                return new StudentsController(studentRepository, schoolRepository, markRepository);
            }
            else if (serviceType == typeof(SchoolsController))
            {
                DbContext context = new StudentSystemContext();
                var schoolRepository = new EfRepository<School>(context);
                var studentRepository = new EfRepository<Student>(context);
                return new SchoolsController(schoolRepository, studentRepository);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
        }
    }
}