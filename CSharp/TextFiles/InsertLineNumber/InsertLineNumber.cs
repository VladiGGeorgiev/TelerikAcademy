/*Write a program that reads a text file and inserts line numbers 
 * in front of each of its lines. The result should be written to 
 * another text file.
*/

namespace InsertLineNumber
{
    using System;
    using System.IO;

    public class InsertLineNumber
    {
        public static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../text.txt"))
            {
                using (StreamWriter writer = new StreamWriter("../../textWithLines.txt"))
                {
                    string lineText = reader.ReadLine();
                    int lineNumber = 1;
                    while (lineText != null)
                    {
                        writer.WriteLine("{0}. {1}", lineNumber, lineText);
                        lineText = reader.ReadLine();
                        lineNumber++;
                    }
                }
            }
        }
    }
}
