using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountDoubleValues
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            IDictionary<double, int> numberOcurances = new SortedDictionary<double, int>();

            foreach (var number in numbers)
            {
                if (numberOcurances.ContainsKey(number))
                {
                    numberOcurances[number]++;
                }
                else
                {
                    numberOcurances.Add(number, 1);
                }
            }

            foreach (var pair in numberOcurances)
            {
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
            }
        }
    }
}
