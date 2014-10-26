using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string separator = Console.ReadLine();

            string[] lines = new string[n]; 

            for (int i = 0; i < n; i++)
            {
                lines[i] = Console.ReadLine();
            }

            List<string> result = new List<string>();
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = lines[i].Trim();
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] == '{')
                    {
                        result.Add(str.ToString());
                        str.Clear();
                        result.Add("{");
                    }
                    else if (lines[i][j] == '}')
                    {
                        if (str.ToString() != "")
                        {
                            result.Add(str.ToString());
                            str.Clear();
                        }
                        result.Add("}");
                    }
                    else
                    {
                        if (lines[i][j] != '}' && lines[i][j] != '{')
                        {
                            str.Append(lines[i][j]);
                        }
                    }
                }
            }

            int inBrackets = 0;
            for (int i = 0; i < result.Count - 1; i++)
            {
                if (result[i].Contains("{"))
                {
                    inBrackets++;
                }

                int a = 0;
                while (a < inBrackets)
	            {
                    result[i+1] = result[i+1].Insert(0, separator);
                    a++;
	            }
                if (result[i].Contains("}"))
                {
                    inBrackets--;
                    result[i] = result[i].Remove(0, separator.Length);
                }
                result[i] = result[i].Remove(0, separator.Length);
            }

            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine(result[i]);
            }
        }
    }
}
