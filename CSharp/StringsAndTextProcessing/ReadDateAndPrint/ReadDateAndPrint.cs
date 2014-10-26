/*Write a program that reads a date and time given in the format: day.month.year hour:minute:second
 * and prints the date and time after 6 hours and 30 minutes (in the same format)
 * along with the day of week in Bulgarian.
*/

namespace ReadDateAndPrint
{
    using System;
    using System.Globalization;

    class ReadDateAndPrint
    {
        static void Main()
        {
            string stringDate = Console.ReadLine();
            DateTime date = DateTime.ParseExact(stringDate, "d.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            date = date.AddHours(6);
            date = date.AddMinutes(30);

            Console.WriteLine(date.ToString());
        }
    }
}
