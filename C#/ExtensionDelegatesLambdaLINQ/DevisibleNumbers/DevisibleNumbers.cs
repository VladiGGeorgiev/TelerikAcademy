using System;
using System.Linq;

namespace DevisibleNumbers
{
    internal class DevisibleNumbers
    {
        internal static void Main()
        {
            int[] array = { 2, 54, 23, 43, 12, 123, 152, 42, 84, 168 };

            var divisibleArray = array.Where(x => (x % 21 == 0));

            foreach (var number in divisibleArray)
            {
                Console.WriteLine(number + " ");
            }

            Console.WriteLine(new string('-', 50));

            var arrayLinq =
                from number in array
                where number % 21 == 0
                select number;

            foreach (var number in arrayLinq)
            {
                Console.WriteLine(number);
            }
        }
    }
}
