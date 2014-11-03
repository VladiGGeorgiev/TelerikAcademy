using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentSystem.Models;

namespace StudentSystem.Services.Models
{
    public class SchoolModel
    {
        public int SchoolId { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }
    }
}