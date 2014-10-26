using System;
using System.Collections.Generic;
using System.IO;

namespace Eratosten
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            var isPrime = new bool[number + 1];

            var array = new List<int>
            { 2, 4, 6, 8, 9, 15, 21, 25, 35, 49, 77, 91, 119, 121, 143, 169, 221, 247, 289, 323, 361, 437, 529, 667, 713, 841, 899, 961, 1147, 1271, 1333, 
                1369, 1517, 1591, 1681, 1763, 1849, 2021, 2209, 2491, 2773, 2809, 3127, 3233, 3481, 3599, 3721, 4087, 4331, 4453, 4489 };
//
//            for (int i = 1; i < array.Count; i++)
//            {
//                if (number < array[i])
//                {
//                    Console.WriteLine(array[i - 1]);
//                    return;
//                }
//            }

            for (int num = 4489; num < 1000000; num += 10)
            {
                int lastNumber = 0;
                for (int i = 2; i <= num; i++)
                {
                    if (!isPrime[i])
                    {
                        for (int j = 2; j <= num / i; j++)
                        {
                            if (!isPrime[i * j])
                            {
                                isPrime[i * j] = true;
                                lastNumber = i * j;
                            }
                        }
                    }
                }

                if (array[array.Count - 1] != lastNumber)
                {
                    array.Add(lastNumber);
                    Console.WriteLine(lastNumber);
                }
            }
        }
    }
}
