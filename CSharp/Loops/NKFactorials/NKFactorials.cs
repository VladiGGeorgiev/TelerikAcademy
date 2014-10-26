/* 4.Write a program that calculates N!/K! for given N and K (1<K<N).
*/
using System;
using System.Numerics;

class NKFactorials
{
    static void Main()
    {
        int N = 15;
        int K = 13;

        BigInteger factorialN = 1;
        BigInteger factorialK = 1;

        for (int i = 1; i <= N; i++)
        {
            factorialN *= i;
            if (i <= K)
            {
                factorialK *= i;
            }
        }
        Console.WriteLine("!{0}/!{1} = {2}", N, K, (factorialN / factorialK));
    }
}
