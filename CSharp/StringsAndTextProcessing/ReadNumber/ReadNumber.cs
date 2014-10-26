/*Write a program that reads a number and prints it as a decimal number, 
 * hexadecimal number, percentage and in scientific notation. 
 * Format the output aligned right in 15 symbols.
*/

namespace ReadNumber
{
    using System;
    
    public class ReadNumber
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            
            Console.WriteLine(string.Format("{0:d15}", number));
            Console.WriteLine(string.Format("{0:x15}", number));
            Console.WriteLine(string.Format("{0:p15}", number));
            Console.WriteLine(string.Format("{0:c15}", number));
        }
    }
}
