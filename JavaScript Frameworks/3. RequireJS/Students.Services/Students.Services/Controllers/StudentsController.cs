using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Students.Services.Models;

namespace Students.Services.Controllers
{
    public class StudentsController : ApiController
    {
        private ICollection<Student> students;

        public StudentsController()
        {
            students = new List<Student>()
                {
                    new Student()
                        {
                            StudentId = 1,
                            Grade = 3,
                            Name = "Pesho",
                            Marks = new List<Mark>()
                                {
                                    new Mark()
                                        {
                                            Score = 88,
                                            Subject = "HTML"
                                        },
                                    new Mark()
                                        {
                                            Score = 77,
                                            Subject = "CSS"
                                        },
                                    new Mark()
                                        {
                                            Score = 67,
                                            Subject = "C#"
                                        }
                                },

                        },
                    new Student()
                        {
                            StudentId = 2,
                            Grade = 2,
                            Name = "Minka",
                            Marks = new List<Mark>()
                                {
                                    new Mark()
                                        {
                                            Score = 97,
                                            Subject = "HTML"
                                        },
                                    new Mark()
                                        {
                                            Score = 65,
                                            Subject = "CSS"
                                        },
                                    new Mark()
                                        {
                                            Score = 82,
                                            Subject = "C#"
                                        }
                                },
                        }
                };
        }

        // GET api/students
        public IEnumerable<Student> Get()
        {
            

            return students.Select(new Func<Student, Student>(x => new Student()
                {
                    StudentId = x.StudentId,
                    Grade = x.Grade,
                    Name = x.Name
                }));
        }

        [HttpGet, ActionName("marks")]
        public ICollection<Mark> Get(int studentId)
        {
            var student = students.FirstOrDefault(st => st.StudentId == studentId);
            
            return student.Marks;
        }
    }
}
