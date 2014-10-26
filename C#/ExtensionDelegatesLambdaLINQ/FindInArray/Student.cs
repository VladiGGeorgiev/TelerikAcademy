using System;
using System.Linq;

namespace FindInArray
{
    public class Student
    {
        private string firstName;
        private string lastName;
        private byte age;

        public byte Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public Student(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public Student(string firstName, string lastName, byte age) : 
            this(firstName, lastName)
        {
            this.age = age;
        }
    }
}
