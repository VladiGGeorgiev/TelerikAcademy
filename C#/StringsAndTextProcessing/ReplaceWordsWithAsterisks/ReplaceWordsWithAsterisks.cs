using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplaceWordsWithAsterisks
{
    class ReplaceWordsWithAsterisks
    {
        static void Main(string[] args)
        {
            string text = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
            string stringWords = "PHP, CLR, Microsoft";

            string[] words = stringWords.Split(',');

            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].Trim();
                text = text.Replace(words[i], new string('*', words[i].Length));
            }

            Console.WriteLine(text);
        }
    }
}
