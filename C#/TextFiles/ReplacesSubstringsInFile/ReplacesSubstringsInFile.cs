/*Write a program that replaces all occurrences of the substring "start"
 * with the substring "finish" in a text file. 
 * Ensure it will work with large files (e.g. 100 MB).
*/

namespace ReplacesSubstringsInFile
{
    using System;
    using System.IO;
    using System.Text;
    using System.Timers;

    class ReplacesSubstringsInFile
    {
        private static void WriteToFile(StringBuilder text)
        {
            using (var writer = new StreamWriter("../../file.txt"))
            {
                writer.WriteLine(text);
            }
        }

        private static StringBuilder ReadFile()
        {
            StringBuilder text = new StringBuilder();

            using (var reader = new StreamReader("../../file.txt"))
            {
                text.Append(reader.ReadToEnd());
            }

            return text;
        }

        static void Main(string[] args)
        {
            string searchedWord = "finish";
            string replacedWord = "start";

            StringBuilder text = new StringBuilder();
            text = ReadFile();

            text.Replace(searchedWord, replacedWord);
 
            WriteToFile(text);
        }
    }
}
