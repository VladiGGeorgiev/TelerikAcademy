namespace StudentClass
{
    using System;

    class Person
    {
        private string name;
        private int? age;

        public Person(string name, int? age = null)
        {
            this.Name = name;
            this.Age = age;
        }

        public int? Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public override string ToString()
        {
            string result = string.Empty;
            result = "Name: " + this.Name + Environment.NewLine;

            if (this.Age == null)
            {
                result += "The age is not specified.";
            }
            else
            {
                result += "Age: " + this.Age;
            }

            return result;
        }
    }
}
