/*Write a program that generates and prints to the console 10 random values in the range [100, 200].
*/

namespace RandomNumbers
{
    using System;

    public class RandomNumbers
    {
        public static void Main(string[] args)
        {
            Random randomNumbers = new Random();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(randomNumbers.Next(100, 201));			 
            }
        }
    }
}
