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
    public class StudentsController : ApiController
    {
        private IRepository<Student> studentRepository;
        private IRepository<School> schoolRepository;
        private IRepository<Mark> markRepository; 

        public StudentsController(IRepository<Student> studentRepository, IRepository<School> schoolRepository, IRepository<Mark> markRepository)
        {
            this.studentRepository = studentRepository;
            this.schoolRepository = schoolRepository;
            this.markRepository = markRepository;
        }

        // GET api/Students
        [HttpGet]
        public IEnumerable<StudentModel> GetStudents()
        {
            var students = this.studentRepository.All().Select(
                new Func<Student, StudentModel>(student => new StudentModel()
            {
                StudentId = student.StudentId,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Age = student.Age,
                Grade = student.Grade,
            }));

            return students;
        }

        // GET api/Students
        public IEnumerable<StudentModel> GetStudents(string subject, double value)
        {
            var students = this.studentRepository.All().Where(x => x.Marks.Any(m => m.Subject == subject && m.Value == value)).Select(
                new Func<Student, StudentModel>(student => new StudentModel()
                {
                    StudentId = student.StudentId,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Age = student.Age,
                    Grade = student.Grade,
                }));

            return students;
        }

        // GET api/Students/5
        public StudentDetailModel GetStudent(int id)
        {
            Student student = this.studentRepository.Get(id);
            if (student == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            var studentEntity = this.studentRepository.Get(id);
            
            StudentDetailModel studentDetailModel = new StudentDetailModel()
                {
                    FirstName = studentEntity.FirstName,
                    LastName = studentEntity.LastName,
                    Grade = studentEntity.Grade,
                    Age = studentEntity.Age,
                    StudentId = studentEntity.StudentId
                };

            var schools = this.schoolRepository.All();
            var school =
                (from s in schools
                 where s.Students.Any(x => x.StudentId == studentEntity.StudentId)
                 select s).First();

            studentDetailModel.School = new SchoolModel()
                {
                    SchoolId = school.SchoolId,
                    Name = school.Name,
                    Location = school.Location
                };

            var marks = this.markRepository.All();
            var studentMarks =
                from mark in marks
                where mark.Student.StudentId == id
                select mark;

            studentDetailModel.Marks = studentMarks.Select(new Func<Mark, MarkModel>(x => new MarkModel()
                {
                    Value = x.Value,
                    Subject = x.Subject,
                    MarkId = x.MarkId
                })).ToList();

            return studentDetailModel;
        }

        // POST api/Students
        public HttpResponseMessage PostStudent(Student student)
        {
            if (student == null)
            {
                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The school is null!");
                return errorResponse;
            }

            var entity = this.studentRepository.Add(student);

            var response = this.Request.CreateResponse(HttpStatusCode.Created, entity);
            response.Headers.Location =
                new Uri(this.Request.RequestUri + student.StudentId.ToString(CultureInfo.InvariantCulture));
            return response;
        }
    }
}