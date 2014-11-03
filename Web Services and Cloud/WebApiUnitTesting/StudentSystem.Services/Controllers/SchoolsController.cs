using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using StudentSystem.Models;
using StudentSystem.Data;
using StudentSystem.Repositories;
using StudentSystem.Services.Models;

namespace StudentSystem.Services.Controllers
{
    public class SchoolsController : ApiController
    {
        private IRepository<School> schoolRepository;
        private IRepository<Student> studentRepository; 

        public SchoolsController(IRepository<School> schoolRepository, EfRepository<Student> studentRepository)
        {
            this.schoolRepository = schoolRepository;
            this.studentRepository = studentRepository;
        }

        // GET api/Schools
        public IEnumerable<SchoolModel> GetSchools()
        {
            return this.schoolRepository.All().Select(new Func<School, SchoolModel>(school => new SchoolModel()
                {
                    SchoolId = school.SchoolId, 
                    Location = school.Location,
                    Name = school.Name,
                }));
        }

        // GET api/Schools/5
        public SchoolDetailModel GetSchool(int id)
        {
            School school = this.schoolRepository.Get(id);
            if (school == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            SchoolDetailModel schoolModel = new SchoolDetailModel()
                {
                    Location = school.Location,
                    Name = school.Name,
                    SchoolId = school.SchoolId,
                };

            var students = this.studentRepository.All();

            var schoolStudents =
                from s in students
                 where s.School.Name == school.Name
                 select s;

            schoolModel.Students = schoolStudents.Select(new Func<Student, StudentModel>(x => new StudentModel()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Grade = x.Grade,
                    Age = x.Age,
                    StudentId = x.StudentId
                })).ToList();

            return schoolModel;
        }

        // POST api/Schools
        public HttpResponseMessage PostSchool(School school)
        {
            if (school == null)
            {
                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The school is null!");
                return errorResponse;
            }

            var entity = this.schoolRepository.Add(school);

            var response = this.Request.CreateResponse(HttpStatusCode.Created, entity);
            response.Headers.Location =
                new Uri(this.Request.RequestUri + school.SchoolId.ToString(CultureInfo.InvariantCulture));
            return response;
        }
    }
}