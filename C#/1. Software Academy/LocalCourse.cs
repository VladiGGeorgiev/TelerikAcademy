using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
    public class LocalCourse : Course, ILocalCourse
    {
        public string Lab { get; set; }

        public LocalCourse(string name, ITeacher teacher, string lab) : base(name, teacher)
        {
            this.Lab = lab;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());

            result.Append("; " + "Lab=" + this.Lab);

            return result.ToString();
        }
    }
}
