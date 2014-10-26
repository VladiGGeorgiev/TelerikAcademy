/*Write a method that adds two positive integer numbers represented as 
 * arrays of digits (each array element arr[i] contains a digit; 
 * the last digit is kept in arr[0]). 
 * Each of the numbers that will be added could have up to 10 000 digits.
*/
namespace AddsTwoArrayNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AddsTwoArrayNumbers
    {
        public static void Main()
        {
            List<int> firstNumber = new List<int>() { 5, 4, 6, 7, 8, 5};

            firstNumber.Reverse();
            Print(firstNumber);

            Console.WriteLine("+");

            List<int> secondNumber = new List<int>() { 2, 4, 6, 1, 2, 3, 5, 6 };
            secondNumber.Reverse();
            Print(secondNumber);

            Console.WriteLine("=");
            SumNumbers(firstNumber, secondNumber);
        }

        private static void Print(List<int> number)
        {
            for (int i = number.Count - 1; i >= 0; i--)
            {
                Console.Write(number[i]);
            }

            Console.WriteLine();
        }

        private static void SumNumbers(List<int> firstNumber, List<int> secondNumber)
        {
            int length = firstNumber.Count;
            if (firstNumber.Count < secondNumber.Count)
            {
                length = secondNumber.Count;
            }

            int remainder = 0;
            int onMind = 0;

            List<int> sumNumber = new List<int>();

            for (int i = 0; i < length; i++)
            {
                if (i < Math.Min(firstNumber.Count, secondNumber.Count)) 
                {
                    // Sum numbers while end digits of smaller number
                    remainder = (firstNumber[i] + secondNumber[i]) % 10;
                    sumNumber.Add(remainder + onMind);
                    onMind = (firstNumber[i] + secondNumber[i]) / 10;
                }
                else 
                {
                    // Add digits of bigger number
                    if (firstNumber.Count > secondNumber.Count)
                    {
                        sumNumber.Add(firstNumber[i] + onMind);
                    }
                    else
                    {
                        sumNumber.Add(secondNumber[i] + onMind);
                    }

                    onMind = 0; // Clear on mind number after end the smaller digits
                }
            }

            Print(sumNumber);
        }
    }
}
