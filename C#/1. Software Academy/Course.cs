using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
    public abstract class Course : ICourse
    {
        public string Name { get; set; }

        public ITeacher Teacher { get; set; }

        private List<string> Topics { get; set; }

        public Course(string name, ITeacher teacher = null)
        {
            this.Topics = new List<string>();
            this.Name = name;
            this.Teacher = teacher;
        }

        public void AddTopic(string topic)
        {
            Topics.Add(topic);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.GetType().Name + ": ");
            result.Append("Name=" + this.Name);
            if (!(this.Teacher == null))
            {
                result.Append("; Teacher=" + this.Teacher.Name);
            }
            if (this.Topics.Count > 0)
            {
                result.Append("; Topics=[");

                foreach (var topic in Topics)
                {
                    result.Append(topic + ", ");
                }
                result.Length -= 2;

                result.Append("]");
            }

            return result.ToString();
        }
    }
}
