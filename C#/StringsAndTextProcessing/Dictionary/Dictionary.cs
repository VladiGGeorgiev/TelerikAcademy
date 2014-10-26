/*A dictionary is stored as a sequence of text lines containing words and their explanations. 
 * Write a program that enters a word and translates it by using the dictionary. 
*/

namespace Dictionary
{
    using System;
    using System.Collections.Generic;

    class Dictionary
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> mydict = new Dictionary<string,string>();
            mydict.Add(".NET", "platform for applications from Microsoft");
            mydict.Add("CLR", "managed execution environment for .NET");
            mydict.Add("namespace", "hierarchical organization of classes");

            while (true)
            {
                Console.Write("Insert word: ");
                string currentWord = Console.ReadLine();
                currentWord = currentWord.ToLower();

                foreach (var item in mydict)
                {
                    if (item.Key.ToLower() == currentWord)
                    {
                        Console.WriteLine("{0} - {1}", item.Key, item.Value);
                        break;
                    }
                }
            }
        }
    }
}
