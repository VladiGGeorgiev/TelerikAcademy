namespace Exceptions
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            DateTime date = DateTime.Now;
            Console.WriteLine(date);

            InvalidRangeException<int> intOutOfRangeException =
                new InvalidRangeException<int>("Enter number from 1 to 100!", 1, 100);

            for (int i = 0; i < 10; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number < intOutOfRangeException.MinValue || number > intOutOfRangeException.MaxValue)
                {
                    throw intOutOfRangeException;
                }
                else
                {
                    Console.WriteLine("Correct number: {0}", number);
                }
            }

            string someDate = "23/6/2008";
            string otherDate = "12/9/2012";

            InvalidRangeException<DateTime> outOfRangeDateTimeException = new InvalidRangeException<DateTime>(
                string.Format("Insert date from {0} to {1}", someDate, otherDate), DateTime.Parse(someDate), DateTime.Parse(otherDate));

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Insert date:");

                DateTime myDate = DateTime.Parse(Console.ReadLine());

                if (myDate.Year < outOfRangeDateTimeException.MinValue.Year ||
                    myDate.Year > outOfRangeDateTimeException.MaxValue.Year)
                {
                    throw outOfRangeDateTimeException;
                }
                else
                {
                    Console.WriteLine("Correct date!");
                }
            }
        }
    }
}
