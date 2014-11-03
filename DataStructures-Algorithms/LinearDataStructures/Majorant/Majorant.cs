using System;
using System.Collections.Generic;
using System.Linq;

namespace Majorant
{
    class Majorant
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 2, 2, 3, 3, 2, 3, 4, 3, 3, 3 };
            int majorantFormula = (numbers.Count / 2) + 1;

            var groupedNumbers = numbers.GroupBy(x => x);

            string result = string.Empty;
            foreach (var group in groupedNumbers)
            {
                if (group.Count() >= majorantFormula)
                {
                    result = string.Format("The majorant is: {0}", group.First());
                }
                else if (result == string.Empty)
                {
                    result = "The majorant does not exists!";
                }
            }

            Console.WriteLine(result);
        }
    }
}
