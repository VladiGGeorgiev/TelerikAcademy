using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentSystem.Models;

namespace StudentSystem.Services.Models
{
    public class StudentModel
    {
        public int StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte Age { get; set; }

        public byte Grade { get; set; }
    }
}