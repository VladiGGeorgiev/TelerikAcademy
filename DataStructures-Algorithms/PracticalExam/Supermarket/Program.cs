using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Supermarket
{
    class Program
    {
        static StringBuilder result = new StringBuilder();
        static Dictionary<string, int> names = new Dictionary<string, int>();
        static BigList<string> list = new BigList<string>();

        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            while (line != "End")
            {
                string[] tokens = line.Split(' ');
                string command = tokens[0];
                if (command == "Append")
                {
                    AppendClient(tokens[1]);
                }
                else if (command == "Serve")
                {
                    ServeClient(int.Parse(tokens[1]));
                }
                else if (command == "Insert")
                {
                    InsertClient(int.Parse(tokens[1]), tokens[2]);
                }
                else if (command == "Find")
                {
                    FindClient(tokens[1]);
                }

                line = Console.ReadLine();
            }
            result.Length--;
            Console.WriteLine(result.ToString());
        }

        private static void AppendClient(string name)
        {
            list.Add(name);
            if (names.ContainsKey(name))
            {
                names[name]++;
            }
            else
            {
                names.Add(name, 1);
            }

            result.AppendLine("OK");
        }

        private static void ServeClient(int count)
        {
            if (count <= list.Count)
            {
                for (int i = 0; i < count; i++)
                {
                    string name = list[0];
                    list.RemoveAt(0);
                    result.Append(name + " ");
                    if (names[name] == 1)
                    {
                        names.Remove(name);
                    }
                    else
                    {
                        names[name]--;
                    }
                }
                result.Length--;
                result.AppendLine();
            }
            else
            {
                result.AppendLine("Error");
            }
        }

        private static void FindClient(string name)
        {
            if (names.ContainsKey(name))
            {
                result.AppendLine(names[name].ToString());
            }
            else
            {
                result.AppendLine(0.ToString());
            }
        }

        private static void InsertClient(int position, string name)
        {
            if (position >= 0 && position <= list.Count)
            {
                list.Insert(position, name);

                if (names.ContainsKey(name))
                {
                    names[name]++;
                }
                else
                {
                    names.Add(name, 1);
                }

                result.AppendLine("OK");
            }
            else
            {
                result.AppendLine("Error");
            }
        }
    }
}
