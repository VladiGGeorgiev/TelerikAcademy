using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsProject
{
    class Student : IComparable
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public int CompareTo(object obj)
        {
            Student otherStudent = obj as Student;
            if (this.LastName.CompareTo(otherStudent.LastName) == 0)
            {
                return this.FirstName.CompareTo(otherStudent.FirstName);
            }
            else
            {
                return this.LastName.CompareTo(otherStudent.LastName);
            }
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
