using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Write a program that finds a set of words (e.g. 1000 words) in a large text (e.g. 100 MB text file). 
 * Print how many times each word occurs in the text.
 * Hint: you may find a C# trie in Internet.
 */
namespace WordsOccuranceInText
{
    class CountWordOccurances
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("../../file.txt");
            string text = reader.ReadToEnd();
            string[] splitedText = text.Split(new char[] { ' ', ',', '.', ';' }, 
                StringSplitOptions.RemoveEmptyEntries);

            Trie trie = TrieFactory.GetTrie() as Trie;
            foreach (var word in splitedText)
            {
                trie.AddWord(word);    
            }

            var words = trie.GetWords();

            StringBuilder sb = new StringBuilder();
            foreach (var word in words)
            {
                sb.AppendLine(word + " -> " + trie.WordCount(word));
            }

            Console.WriteLine(sb);
        }
    }
}
