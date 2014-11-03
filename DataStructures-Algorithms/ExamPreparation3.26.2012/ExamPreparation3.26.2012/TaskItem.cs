using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks._26._2012
{
    class TaskItem : IComparable
    {
        public TaskItem(string name, int complexity)
        {
            this.Name = name;
            this.Complexity = complexity;
        }

        public string Name { get; set; }

        public int Complexity { get; set; }

        public int CompareTo(object obj)
        {
            var otherTask = obj as TaskItem;
            if (this.Complexity.CompareTo(otherTask.Complexity) == 0)
            {
                return this.Name.CompareTo(otherTask.Name);
            }
            else
            {
                return this.Complexity.CompareTo(otherTask.Complexity);
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
