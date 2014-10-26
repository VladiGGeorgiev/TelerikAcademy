/* Write a program that reads from the console a string of maximum 20 characters. 
 * If the length of the string is less than 20, the rest of the characters should be filled with '*'. 
 * Print the result string into the console.
*/

namespace FillStringWithStars
{
    using System;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            string text = string.Empty;
            while (text.Length > 20 || text == string.Empty)
            {
                Console.Write("Insert text smaller tha 20 symbols: ");
                text = Console.ReadLine();
            }

            var modText = new StringBuilder();

            modText.Append(text);

            if (text.Length < 20)
            {
                modText.Append('*', 20 - text.Length);
            }

            Console.WriteLine(modText);
        }
    }
}
