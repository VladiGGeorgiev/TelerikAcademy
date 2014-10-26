using System;
using System.Collections.Generic;

namespace School
{
    class School
    {
        private string name;
        private List<Class> classes;

        /// <summary>
        /// Initializes a new instance of the <see cref="School" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public School(string name)
        {
            this.name = name;
            this.classes = new List<Class>();
        }

        public string Name
        {
            get { return this.name; }
        }

        public List<Class> Classes
        {
            get 
            { 
                return this.classes; 
            }
        }

        public void AddClass(Class newClass)
        {
            this.classes.Add(newClass);
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
