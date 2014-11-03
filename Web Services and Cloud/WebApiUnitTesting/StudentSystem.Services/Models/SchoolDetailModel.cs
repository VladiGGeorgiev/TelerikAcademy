using StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentSystem.Services.Models
{
    public class SchoolDetailModel
    {
        public int SchoolId { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public virtual ICollection<StudentModel> Students { get; set; }
    }
}