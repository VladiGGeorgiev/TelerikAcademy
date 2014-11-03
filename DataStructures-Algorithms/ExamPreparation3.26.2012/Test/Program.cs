using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

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

class Program
{
    static OrderedBag<TaskItem> tasks = new OrderedBag<TaskItem>();

    static void Main(string[] args)
    {
        StringBuilder sb = new StringBuilder();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine();
            string[] splitedCommand = line.Split(new char[] { ' ' }, 3);
            string command = splitedCommand[0];

            if (command == "New")
            {
                int complexity = int.Parse(splitedCommand[1]);
                string name = splitedCommand[2];

                name = name.TrimEnd();

                tasks.Add(new TaskItem(name, complexity));
            }
            else
            {
                if (tasks.Count > 0)
                {
                    sb.AppendLine(tasks.RemoveFirst().ToString());
                }
                else
                {
                    sb.AppendLine("Rest");
                }
            }
        }

        Console.Write(sb);
    }
}
