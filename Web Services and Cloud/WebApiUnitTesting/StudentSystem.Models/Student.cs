using System.Collections.Generic;

namespace StudentSystem.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte Age { get; set; }

        public byte Grade { get; set; }

        public virtual ICollection<Mark> Marks { get; set; }

        public School School { get; set; }
    }
}
