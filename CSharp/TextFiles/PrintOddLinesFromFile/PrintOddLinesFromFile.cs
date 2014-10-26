/*Write a program that reads a text file and prints on the console its odd lines.
*/

/*  File content:
    This is first line. Minka is the most beautiful girl!
    This is second line. Dimitrichka has the sweetest ass!
    This is third line. Bubka is my lover girl!
    This is fourth line. Duda have green socks!
    This is fifth line. Mimeto like lollipops!
*/

namespace PrintOddLinesFromFile
{
    using System;
    using System.IO;

    public class PrintOddLinesFromFile
    {
        public static void Main()
        {
            string text = string.Empty;
            using (StreamReader reader = new StreamReader(@"..\..\test.txt"))
            {
                text = reader.ReadLine();
                int line = 1;
                while (text != null)
                {
                    if (line % 2 == 1)
                    {
                        Console.WriteLine(text);
                    }

                    text = reader.ReadLine();
                    line++;
                }
            }
        }
    }
}
