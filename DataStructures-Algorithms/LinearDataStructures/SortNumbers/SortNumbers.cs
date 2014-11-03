using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortNumbers
{
    class SortNumbers
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            string line = Console.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                int number = int.Parse(line);
                numbers.Add(number);

                line = Console.ReadLine();
            }

            numbers.Sort();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
