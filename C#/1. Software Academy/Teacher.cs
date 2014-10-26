using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
    public class Teacher : ITeacher
    {
        public string Name { get; set; }

        private List<ICourse> Courses;

        public Teacher(string name)
        {
            this.Name = name;
            this.Courses = new List<ICourse>();
        }

        public void AddCourse(ICourse course)
        {
            Courses.Add(course);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.GetType().Name + ": ");
            result.Append("Name=" + this.Name);
            if (Courses.Count > 0)
            {
                result.Append("; Courses=[");

                foreach (var course in Courses)
                {
                    result.Append(course.Name + ", ");
                }

                result.Length -= 2;

                result.Append("]");
            }

            return result.ToString();
        }
    }
}
