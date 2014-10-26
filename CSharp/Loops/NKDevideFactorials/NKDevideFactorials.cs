/*5.Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).
*/
using System;
using System.Numerics;

class NKDevideFactorials
{
    static void Main()
    {
        int N = 15;
        int K = 22;
        int KN = K - N;

        BigInteger factorialN = 1;
        BigInteger factorialK = 1;
        BigInteger factorialKN = 1;

        for (int i = 1; i <= K; i++)
        {
            factorialK *= i;
            if (i <= N)
            {
                factorialN *= i;
            }
            if (i <= KN)
	        {
		        factorialKN *= i;
	        }
        }
        BigInteger result = factorialN * factorialK / factorialKN;
        Console.WriteLine("{0}! * {1}! / ({2} - {3})! = {4}", N, K, K, N, result);
    }
}
