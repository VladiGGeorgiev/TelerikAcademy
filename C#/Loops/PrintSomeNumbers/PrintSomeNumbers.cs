/* 2.Write a program that prints all the numbers from 1 to N,
 * that are not divisible by 3 and 7 at the same time.
*/
using System;

class PrintSomeNumbers
{
    static void Main()
    {
        int N = 100;
        for (int i = 1; i <= N; i++)
        {
            if (i % 3 == 0 && i % 7 == 0)
            {
                continue;
            }
            Console.WriteLine(i);
        }
    }
}