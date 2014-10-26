/*Write a program that prints to the console which day of the week is today. Use System.DateTime.
*/

namespace PrintDayOfWeek
{
    using System;

    public class PrintDayOfWeek
    {
        public static void Main()
        {
            DateTime today = DateTime.Today;
            Console.WriteLine(today.DayOfWeek);
        }
    }
}
