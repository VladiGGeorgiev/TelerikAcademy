namespace School
{
    using System;
    using System.Collections.Generic;

    public class School
    {
        private string name;
        private List<Course> courses;
        
        public School(string name, List<Course> courses)
        {
            this.Name = name;
            this.Courses = courses;
        }

        /// <summary>
        /// Gets or sets the courses.
        /// </summary>
        /// <value>The courses.</value>
        public List<Course> Courses
        {
            get
            {
                return this.courses;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Courses can not be null!");
                }

                if (value.Count == 0)
                {
                    throw new ArgumentException("Courses can not be with length 0");
                }
                
                this.courses = value;
            }
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

        public void AddCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("Course can not be null!");
            }

            if (this.courses.Contains(course))
            {
                throw new ArgumentException("Course is already exist in this school!");
            }

            this.Courses.Add(course);
        }

        public void RemoveCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("Course can not be null!");
            }

            if (!this.courses.Contains(course))
            {
                throw new ArgumentException("The course you want to remove is not contains in school!");
            }

            this.courses.Remove(course);
        }
    }
}
