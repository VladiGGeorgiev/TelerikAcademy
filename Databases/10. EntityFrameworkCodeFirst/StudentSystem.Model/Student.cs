namespace StudentSystem.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Student
    {
        private ICollection<Course> courses;

        public Student()
        {
            courses = new HashSet<Course>();
        }

        public int Id { get; set; }

        [MaxLength(50)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The Student must have name!")]
        public string Name { get; set; }
        
        public byte? Age { get; set; }

        [Required(ErrorMessage="Student must have number!")]
        public int Number { get; set; }

        public virtual ICollection<Course> Courses
        {
            get
            {
                return this.courses;
            }
            set
            {
                this.courses = value;
            }
        }
    }
}
