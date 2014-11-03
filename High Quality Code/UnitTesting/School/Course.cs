namespace School
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        private string name;
        private List<Student> students;
        
        public Course(string name, List<Student> students)
        {
            this.Name = name;
            this.Students = students;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The name is missing!");
                }

                if (value == string.Empty)
                {
                    throw new ArgumentException("The name can not be empty string!");
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Gets or sets the students.
        /// </summary>
        /// <value>The students.</value>
        public List<Student> Students
        {
            get
            {
                return this.students;
            }

            set
            {
                if (value.Count > 30)
                {
                    throw new ArgumentOutOfRangeException("Students in a course shtould be less than 30!");
                }

                this.students = value;
            }
        }

        /// <summary>
        ///     Add student in current course
        /// </summary>
        /// <param name="student">Student you want to add.</param>
        public void AddStudent(Student student)
        {
            if (Students.Count >= 30)
            {
                throw new ArgumentOutOfRangeException("Students in a course should be less than 30!");
            }

            this.Students.Add(student);
        }

        /// <summary>
        ///     Remove student from current course
        /// </summary>
        /// <param name="student">Student you want to remove.</param>
        public void RemoveStudent(Student student)
        {
            if (this.Students.Contains(student))
            {
                this.Students.Remove(student);
            }
            else
            {
                throw new MissingMemberException("The student can not be found in course!");
            }
        }
    }
}
