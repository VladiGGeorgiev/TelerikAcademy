using System;
using System.Collections.Generic;
using System.Linq;

namespace CountNumbersOccurs
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

            var groupedNumbers = numbers.GroupBy(x => x);
            var sortedGroupedNumbers = groupedNumbers.OrderBy(x => x.First());

            foreach (var group in sortedGroupedNumbers)
            {
                int currentNumber = group.First();
                int currentNumbersCount = group.Count();
                Console.WriteLine("{0} - {1} times", currentNumber, currentNumbersCount);        
            }
        }
    }
}
