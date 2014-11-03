using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "This is the TEXT. Text, text, text - THIS TEXT! Is this the text?";
            text = text.ToLower();
            string[] words = text.Split(new char[] { ' ', '.', ',', '-', '!', '?' }, 
                StringSplitOptions.RemoveEmptyEntries);
            IDictionary<string, int> wordOcurances = new SortedDictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                if (wordOcurances.ContainsKey(words[i]))
                {
                    wordOcurances[words[i]]++;
                }
                else
                {
                    wordOcurances.Add(words[i], 1);
                }
            }

            var orderedWords = wordOcurances.OrderBy(x => x.Value);
            foreach (var pair in orderedWords)
            {
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
            }
        }
    }
}
