using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveOddNumbers
{
    class RemoveOddNumbers
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 4, 2, 2, 5, 7, 2, 3, 2, 3, 1, 5, 2 }; // {5, 3, 3, 5}
            var groupedNumbers = numbers.GroupBy(x => x);

            List<int> resultNumbers = new List<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                foreach (var groupedNumber in groupedNumbers)
                {
                    if (groupedNumber.Count() % 2 == 0 && numbers[i] == groupedNumber.First())
                    {
                        resultNumbers.Add(groupedNumber.First());
                    }
                }
            }

            Console.WriteLine(string.Join(" ", resultNumbers));
        }
    }
}
