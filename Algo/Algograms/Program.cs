using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algograms
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = new List<string>();
            string word = Console.ReadLine();
            while (word != "-1")
            {
                words.Add(word);
                word = Console.ReadLine();
            }

            var arrays = new List<char[]>();

            for (int i = 0; i < words.Count; i++)
            {
                char[] szArr = words[i].ToCharArray();
                Array.Sort(szArr);
                arrays.Add(szArr);
            }

            var result = 1;
            for (int i = 0; i < arrays.Count - 1; i++)
            {
                for (int j = i + 1; j < arrays.Count; j++)
                {
                    if (arrays[i].SequenceEqual(arrays[j]))
                    {
                        arrays.Remove(arrays[i]);
                        j = i;
                    }
                }
            }

            Console.WriteLine(arrays.Count);
        }
    }
}
