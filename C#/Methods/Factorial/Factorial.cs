/*Write a program to calculate n! for each n in the range [1..100]. 
 * Hint: Implement first a method that multiplies a number 
 * represented as array of digits by given integer number. 
*/
namespace Factorial
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    class Factorial
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.Millisecond);
            int startNumber = 1;
            int endNumber = 100;
            PrintFactorials(startNumber, endNumber);
            Console.WriteLine(DateTime.Now.Millisecond);
        }

        private static void PrintFactorials(int startNumber, int endNumber)
        {
            BigInteger result = 1;
            for (int number = startNumber; number <= endNumber; number++)
            {
                result *= number;
                Console.WriteLine(result);
            }
        }
    }
}
