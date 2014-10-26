using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindStudentInAgeRange
{
    public class Student
    {
        public string firstName;
        public string lastName;
        public byte age;

        public Student(string firstName, string lastName, byte age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
