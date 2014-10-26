using System;
using System.Globalization;

namespace DatesDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            DateTime first = DateTime.ParseExact(firstDate, "d.mm.yyyy", CultureInfo.InvariantCulture);

            DateTime second = DateTime.ParseExact(secondDate, "d.mm.yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine((first - second).TotalDays);

        }
    }
}
