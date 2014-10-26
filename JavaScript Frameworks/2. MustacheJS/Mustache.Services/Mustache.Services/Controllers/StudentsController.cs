using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mustache.Services.Models;

namespace Mustache.Services.Controllers
{
    public class StudentsController : ApiController
    {
        // GET api/default1
        public IEnumerable<Student> Get()
        {
            return new List<Student>()
                {
                    new Student()
                        {
                            Age = 18,
                            FirstName = "Pesho",
                            Grade = 4,
                            LastName = "Peshev",
                            Marks = new List<Mark>()
                                {
                                    new Mark()
                                        {
                                            Score = 14,
                                            Subject = "Math"
                                        },
                                    new Mark()
                                        {
                                            Score = 22,
                                            Subject = "Bulgarian"
                                        },
                                    new Mark()
                                        {
                                            Subject = "Sport",
                                            Score = 77
                                        }
                                }
                        },
                        new Student()
                        {
                            Age = 32,
                            FirstName = "Marko",
                            Grade = 8,
                            LastName = "Denev",
                            Marks = new List<Mark>()
                                {
                                    new Mark()
                                        {
                                            Score = 33,
                                            Subject = "Math"
                                        },
                                    new Mark()
                                        {
                                            Score = 55,
                                            Subject = "Bulgarian"
                                        },
                                    new Mark()
                                        {
                                            Subject = "Sport",
                                            Score = 34
                                        }
                                }
                        },
                        new Student()
                        {
                            Age = 55,
                            FirstName = "Plamen",
                            Grade = 5,
                            LastName = "Grozev",
                            Marks = new List<Mark>()
                                {
                                    new Mark()
                                        {
                                            Score = 87,
                                            Subject = "Math"
                                        },
                                    new Mark()
                                        {
                                            Score = 54,
                                            Subject = "Bulgarian"
                                        },
                                    new Mark()
                                        {
                                            Subject = "Sport",
                                            Score = 99
                                        }
                                }
                        }
                };
        }

        // GET api/default1/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/default1
        public void Post([FromBody]string value)
        {
        }

        // PUT api/default1/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/default1/5
        public void Delete(int id)
        {
        }
    }
}
