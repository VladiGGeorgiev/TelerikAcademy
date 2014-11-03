using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Businessmen
{
    class Businessmen
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(FirstOption(number / 2));
        }

        private static BigInteger Factorial(BigInteger n)
        {
            if (n == 0)
                return 1;

            return n * Factorial(n - 1);
        }

        public static BigInteger FirstOption(BigInteger n)
        {
            BigInteger topMultiplier = 2;
            return Factorial(topMultiplier * n) / (Factorial(n + 1) * Factorial(n));
        }
    }
}
