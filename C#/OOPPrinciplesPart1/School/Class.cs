using System;
using System.Collections.Generic;
using System.Linq;

namespace School
{
    class Class : ICommentable
    {
        private List<Student> students = new List<Student>();
        private List<Teacher> teachers = new List<Teacher>();
        private readonly string uniqueId;
        private List<string> comments;

        public Class(string uniqueId)
        {
            this.uniqueId = uniqueId;
            this.comments = new List<string>();
        }
        
        public string UniqueId
        {
            get
            {
                return this.uniqueId;
            }
        }

        internal List<Teacher> Teachers
        {
            get { return this.teachers; }
        }

        internal List<Student> Students
        {
            get { return this.students; }
        }

        public void AddTeachers(Teacher teacher)
        {
            this.teachers.Add(teacher);
        }

        public void AddTeachers(List<Teacher> teachers)
        {
            this.teachers = teachers;
        }

        public void AddStudents(Student student)
        {
            this.students.Add(student);
        }

        public void AddStudents(List<Student> students)
        {
            this.students = students;
        }

        public void AddComment(string comment)
        {
            this.comments.Add(comment);
        }

        public override string ToString()
        {
            return this.uniqueId;
        }
    }
}
