/*Write a program that reads a list of words, separated by spaces and prints the list 
 * in an alphabetical order.
*/

namespace ReadWordsAndSort
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            string stringWords = "milk cow speaker alcohol sky fly spoon foot glass";

            string[] words = stringWords.Split(' ');
            Array.Sort(words);

            Console.WriteLine(string.Join(", ", words));
        }
    }
}
