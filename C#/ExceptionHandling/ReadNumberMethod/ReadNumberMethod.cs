/*Write a method ReadNumber(int start, int end) that enters an integer number in given range [start…end].
 * If an invalid number or non-number text is entered, the method should throw an exception.
 * Using this method write a program that enters 10 numbers:
        a1, a2, … a10, such that 1 < a1 < … < a10 < 100
*/

namespace ReadNumberMethod
{
    using System;

    public class ReadNumberMethod
    {
        public static void Main()
        {
            int start = 0;
            int end = 100;
            for (int i = 0; i < 10; i++)
            {
                start = ReadNumber(start, end);
            }
        }

        private static int ReadNumber(int start, int end)
        {
            int number = 0;
            try
            {
                number = int.Parse(Console.ReadLine());
                if (number < start || number > end)
                {
                    throw new IndexOutOfRangeException();
                }
            }
            catch (IndexOutOfRangeException re)
            {
                Console.WriteLine("The number is out of range! It must be between {0} and {1}", start, end);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please insert a number!");
            }

            return number;
        }
    }
}
