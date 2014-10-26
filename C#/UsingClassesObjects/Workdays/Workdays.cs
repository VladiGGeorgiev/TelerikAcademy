/*Write a method that calculates the number of workdays between today and given date,
 * passed as parameter. Consider that workdays are all days from Monday to Friday except 
 * a fixed list of public holidays specified preliminary as array.
*/

namespace Workdays
{
    using System;
    using System.Collections.Generic;

    public class Workdays
    {
        public static void Main(string[] args)
        {
            DateTime finalDay = ReadFinalDay();
            DateTime currentDay = DateTime.Today;

            List<DateTime> holidays = new List<DateTime>()
            {
                new DateTime(2013, 1, 1),
                new DateTime(2013, 3, 3),
                new DateTime(2013, 5, 24),
                new DateTime(2013, 9, 22),
                new DateTime(2013, 12, 24),
                new DateTime(2013, 12, 25),
                new DateTime(2013, 12, 26),
                new DateTime(2013, 12, 31),
            };

            int daysElapsed = CountDays(finalDay, ref currentDay, holidays);
            Console.WriteLine(daysElapsed);
        }

        private static int CountDays(DateTime finalDay, ref DateTime currentDay, List<DateTime> holidays)
        {
            int daysElapsed = 0;

            while (currentDay <= finalDay)
            {
                if (currentDay.DayOfWeek != DayOfWeek.Saturday && currentDay.DayOfWeek != DayOfWeek.Sunday)
                {
                    daysElapsed++;
                    currentDay = currentDay.AddDays(1);
                }
                else
                {
                    currentDay = currentDay.AddDays(1);
                }

                for (int i = 0; i < holidays.Count; i++)
                {
                    if (currentDay == holidays[i])
                    {
                        daysElapsed--;
                        break;
                    }
                }
            }

            return daysElapsed;
        }

        private static DateTime ReadFinalDay()
        {
            int day = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());

            DateTime futureDate = new DateTime(year, month, day);
            return futureDate;
        }
    }
}
