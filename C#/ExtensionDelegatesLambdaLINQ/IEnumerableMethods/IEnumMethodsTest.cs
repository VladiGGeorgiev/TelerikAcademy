using System;
using System.Collections.Generic;
using System.Linq;

namespace IEnumerableMethods
{
    internal class IEnumMethodsTest
    {
        internal static void Main(string[] args)
        {
            List<string> peshho = new List<string>();
            peshho.Add("2");
            peshho.Add("12");
            peshho.Add("3");
            peshho.Product();
            Console.WriteLine(peshho.Product());

            Console.WriteLine(peshho.Sum());
            Console.WriteLine(peshho.Average());
        }
    }
}
