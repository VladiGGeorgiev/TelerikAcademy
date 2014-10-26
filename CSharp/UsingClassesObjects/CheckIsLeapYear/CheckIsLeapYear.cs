/*Write a program that reads a year from the console and checks whether it is a leap. Use DateTime.
*/
namespace CheckIsLeapYear
{
    using System;

    public class CheckIsLeapYear
    {
        public static void Main(string[] args)
        {
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Is it leap {0} year? {1}", year, DateTime.IsLeapYear(year));
        }
    }
}
