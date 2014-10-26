/*Write a program that reads an integer number and calculates and prints its square root. 
 * If the number is invalid or negative, print "Invalid number".
 * In all cases finally print "Good bye". Use try-catch-finally.
*/

namespace NumberSquareRoot
{
    using System;

    public class NumberSquareRoot
    {
        public static void Main()
        {
            try
            {
                uint number = uint.Parse(Console.ReadLine());
                Console.WriteLine(Math.Sqrt(number));
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Invalid number!");
                throw;
            }
            catch (FormatException)
            {
                Console.WriteLine("Ïnvalid number!");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Try with positive number!");
            }
            finally 
            {
                Console.WriteLine("Good bye!");
            }
        }
    }
}
