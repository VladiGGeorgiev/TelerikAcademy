/*Write a program that compares two text files line by line 
 * and prints the number of lines that are the same and the
 * number of lines that are different. Assume the files have
 * equal number of lines.
*/

namespace CompareFiles
{
    using System;
    using System.IO;

    public class CompareFiles
    {
        public static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../text.txt"))
            {
                using (StreamReader reader2 = new StreamReader("../../text2.txt"))
                {
                    int sameLinesCounter = 0;
                    int differentLinesCounter = 0;
                    string text = reader.ReadLine();
                    string text2 = reader2.ReadLine();
                    while (text != null || text2 != null)
                    {
                        if (text == text2)
                        {
                            sameLinesCounter++;
                        }
                        else
                        {
                            differentLinesCounter++;
                        }

                        text = reader.ReadLine();
                        text2 = reader2.ReadLine();
                    }

                    Console.WriteLine("Same lines are: " + sameLinesCounter);
                    Console.WriteLine("Different line are: " + differentLinesCounter);
                }
            }
        }
    }
}
