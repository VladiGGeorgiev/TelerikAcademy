using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentSystem.Services.Models
{
    public class StudentDetailModel
    {
        public int StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte Age { get; set; }

        public byte Grade { get; set; }

        public virtual ICollection<MarkModel> Marks { get; set; }

        public SchoolModel School { get; set; }
    }
}