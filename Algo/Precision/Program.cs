using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Precision
{
    struct frac {
        public int num;
        public int denom;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var frac = to_frac(3.14, 5);
            Console.WriteLine(frac.num + "/" + frac.denom);
        }
        static int gcd(int a, int b)
        {
            if (a == 0) return b;
            if (b == 0) return a;

            if (a > b)
                return gcd(b, a % b);
            else
                return gcd(a, b % a);
        }

        static frac to_frac(double x, int precision)
        {
            int denom = 1;
            for (int i = 0; i < precision; i++) {
                denom *= 10;
            }

            double num = x * denom + 0.5; // hack: round if imprecise
            int gcdiv = gcd((int)num, denom);

            frac f = new frac();
            f.num = (int)(num / gcdiv);
            f.denom = denom / gcdiv;

            return f;
        }
    }

    
}



