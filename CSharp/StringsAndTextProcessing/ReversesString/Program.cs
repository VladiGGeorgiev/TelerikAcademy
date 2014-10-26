/*Write a program that reads a string, reverses it and prints the result at the console.
Example: "sample"  "elpmas".
*/

namespace ReversesString
{
    using System;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            string car = "AstonMartin";

            string reversedCar = ReverseString(car);

            Console.WriteLine(reversedCar);
        }

        private static string ReverseString(string car)
        {
            StringBuilder reversedCar = new StringBuilder();

            for (int i = (car.Length - 1); i >= 0; i--)
            {
                reversedCar.Append(car[i]);
            }

            return reversedCar.ToString();
        }
    }
}
