/*Write a program that reads a text file containing a list of strings, 
 * sorts them and saves them to another text file. Example:
	Ivan			George
	Peter			Ivan
	Maria			Maria
	George			Peter
*/

namespace SortStringsFromFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class SortStringsFromFile
    {
        public static void Main(string[] args)
        {
            string[] names = ReadNames();

            Array.Sort(names);

            SaveSortedNamesInFile(names);
        }

        private static void SaveSortedNamesInFile(string[] names)
        {
            using (var writer = new StreamWriter("../../SortedNames.txt"))
            {
                for (int i = 0; i < names.Length; i++)
                {
                    writer.WriteLine(names[i]);
                }
            }
        }

        private static string[] ReadNames()
        {
            List<string> listNames = new List<string>();
            using (StreamReader reader = new StreamReader("../../names.txt"))
            {
                string name = reader.ReadLine();

                while (name != null)
                {
                    listNames.Add(name);
                    name = reader.ReadLine();
                }
            }

            string[] names = ConvertListToArray(listNames);

            return names;
        }

        private static string[] ConvertListToArray(List<string> names)
        {
            string[] arrayNames = new string[names.Count];

            for (int i = 0; i < names.Count; i++)
            {
                arrayNames[i] = names[i];
            }

            return arrayNames;
        }
    }
}
