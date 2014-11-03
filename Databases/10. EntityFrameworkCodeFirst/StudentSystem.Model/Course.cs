namespace StudentSystem.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Course
    {
        private ICollection<string> materials;
        private ICollection<Student> students;

        public Course()
        {
            materials = new HashSet<string>();
            students = new HashSet<Student>();
        }

        public int Id { get; set; }

        [MaxLength(50)]
        [Required(AllowEmptyStrings=false, ErrorMessage="Course must have name!")]
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<string> Materials
        {
            get
            {
                return this.materials;
            }
            set
            {
                this.materials = value;
            }
        }

        public virtual ICollection<Student> Students
        {
            get
            {
                return this.students;
            }
            set
            {
                this.students = value;
            }
        }
    }
}
