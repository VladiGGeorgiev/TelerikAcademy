/*You are given a sequence of positive integer values written into a string, separated by spaces. 
 * Write a function that reads these values from given string and calculates their sum. Example:
		string = "43 68 9 23 318"  result = 461
*/

namespace SumStringNumbers
{
    using System;

    public class SumStringNumbers
    {
        public static void Main(string[] args)
        {
            string numbers = "43 68 9 23 318";
            string[] arrayNumbers = numbers.Split(' ');

            int sum = 0;
            for (int i = 0; i < arrayNumbers.Length; i++)
            {
                sum += int.Parse(arrayNumbers[i]);
            }

            Console.WriteLine(sum);
        }
    }
}
