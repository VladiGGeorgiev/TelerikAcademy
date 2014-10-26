using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CubicRott
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger number = BigInteger.Parse(Console.ReadLine());

            Console.WriteLine(Cbrt(number));
        }

        public static BigInteger Cbrt(BigInteger n)
        {
            return GetCubicRoot(n, 0, n);
        }

        public static BigInteger GetCubicRoot(BigInteger n, BigInteger low, BigInteger high)
        {
            BigInteger cbrt = (low + high) / 2;
            if (cbrt * cbrt * cbrt > n)
                return GetCubicRoot(n, low, cbrt);
            if (cbrt * cbrt * cbrt < n)
                return GetCubicRoot(n, cbrt, high);
            return cbrt;
        }
    }
}
