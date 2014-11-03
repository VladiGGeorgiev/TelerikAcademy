using System;
using System.Text;
using System.Threading.Tasks;
using Tasks._26._2012;
using Wintellect.PowerCollections;

namespace Tasks
{
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
}