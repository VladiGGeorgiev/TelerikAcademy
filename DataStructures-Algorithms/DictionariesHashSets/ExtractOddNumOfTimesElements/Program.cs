using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractOddNumOfTimesElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
            IDictionary<string, int> wordOcurances = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (wordOcurances.ContainsKey(word))
                {
                    wordOcurances[word]++;
                }
                else
                {
                    wordOcurances[word] = 1;
                }
            }

            foreach (var pair in wordOcurances)
            {
                if (pair.Value % 2 == 1)
                {
                    Console.WriteLine(pair.Key);
                }
            }
        }
    }
}
