using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1
{
    class Program
    {
        static Dictionary<string, int> votes = new Dictionary<string, int>(); 

        static void Main()
        {
            ReadFromFile();

            int maxVote = int.MinValue;
            int minVote = int.MaxValue;

            foreach (var vote in votes)
            {
                if (vote.Value > maxVote)
                {
                    maxVote = vote.Value;
                }

                if (vote.Value < minVote)
                {
                    minVote = vote.Value;
                }
            }

            SaveToFile(maxVote, minVote);
        }

        private static void ReadFromFile()
        {
            using (var reader = new StreamReader("class.in"))
            {
                string line = reader.ReadLine();
                int counter = int.Parse(line);
                line = reader.ReadLine();
                while (counter > 0)
                {
                    if (votes.ContainsKey(line))
                    {
                        votes[line]++;
                    }
                    else
                    {
                        votes.Add(line, 1);
                    }

                    line = reader.ReadLine();
                    counter--;
                }
            }
        }

        private static void SaveToFile(int max, int min)
        {
            var writer = new StreamWriter("class.out");
            using (writer)
            {
                writer.WriteLine();
            }
        }
    }
}
