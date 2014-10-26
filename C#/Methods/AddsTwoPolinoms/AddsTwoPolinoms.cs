/*Write a method that adds two polynomials. Represent them as arrays of their coefficients as in the example below:
		x2 + 5 = 1x2 + 0x + 5 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddsTwoPolinoms
{
    class AddsTwoPolinoms
    {
        static void Main(string[] args)
        {
            int[] firstPolynom = { 4, 3, -11, 2 };
            int[] secondPolynom = { 2, 4, 5, 1 };

            int[] result = AddsPolynoms(firstPolynom, secondPolynom);
            Array.Reverse(result);
            Print(result);
        }

        private static void Print(int[] result)
        {
            Console.WriteLine(string.Join(" ", result)); 
        }

        private static int[] AddsPolynoms(int[] firstPolynom, int[] secondPolynom)
        {
            int biggerLength = Math.Max(firstPolynom.Length, secondPolynom.Length);
            int[] sumPolynom = new int[biggerLength];

            for (int i = 0; i < biggerLength; i++)
            {
                sumPolynom[i] = firstPolynom[i] + secondPolynom[i];
            }

            return sumPolynom;
        }
    }
}
