/*Write a program that concatenates two text files into another text file.
*/

namespace ConcatenateTextFiles
{
    using System;
    using System.IO;

    public class ConcatenateTextFiles
    {
        public static void Main()
        {
            string firstFilePath = @"..\..\firstFile.txt";
            string secondFilePath = @"..\..\secondFile.txt";

            string firstFileText = ReadFile(firstFilePath);
            string secondFileText = ReadFile(secondFilePath);
            string allText = firstFileText + secondFileText;

            CreateFile(allText);
        }

        private static void CreateFile(string allText)
        {
            using (StreamWriter writer = new StreamWriter(@"..\..\concatenate.txt"))
            {
                writer.WriteLine(allText);
            }
        }

        private static string ReadFile(string filePath)
        {
            string text = string.Empty;
            using (StreamReader reader = new StreamReader(filePath))
            {
                text = reader.ReadToEnd();
            }

            return text;
        }
    }
}
