using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskWinsRiskLoses
{
    class RiskWinsRiskLoses
    {
        static string startCombination;
        static string endCombination;
        static HashSet<string> forbidden = new HashSet<string>();
        static int result = -1;

        static void Main(string[] args)
        {
            startCombination = Console.ReadLine();
            endCombination = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                forbidden.Add(Console.ReadLine());
            }

            BFS();
            Console.WriteLine(result);
        }

        static void BFS()
        {
            Queue<Tuple<string, int>> queue = new Queue<Tuple<string, int>>();
            queue.Enqueue(new Tuple<string, int>(startCombination, 0));
            forbidden.Add(startCombination);

            StringBuilder sb;
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current.Item1 == endCombination)
                {
                    result = current.Item2;
                    return;
                }

                sb = new StringBuilder(current.Item1);
                for (int i = 0; i < 5; i++)
                {
                    int currentDigit = current.Item1[i] - '0';
                    if (currentDigit != 9)
                    {
                        sb[i]++;
                    }
                    else
                    {
                        sb[i] = '0';
                    }

                    var newCombination = sb.ToString();
                    if (!forbidden.Contains(newCombination))
                    {
                        queue.Enqueue(new Tuple<string, int>(sb.ToString(), current.Item2 + 1));
                        forbidden.Add(sb.ToString());
                    }

                    sb[i] = current.Item1[i];
                }

                for (int i = 0; i < 5; i++)
                {
                    int currentDigit = current.Item1[i] - '0';
                    if (currentDigit != 0)
                    {
                        sb[i]--;
                    }
                    else
                    {
                        sb[i] = '9';
                    }

                    var newCombination = sb.ToString();
                    if (!forbidden.Contains(newCombination))
                    {
                        queue.Enqueue(new Tuple<string, int>(sb.ToString(), current.Item2 + 1));
                        forbidden.Add(sb.ToString());
                    }

                    sb[i] = current.Item1[i];
                }
            }
        }
    }
}
