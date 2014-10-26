/*6. Write a program that, for a given two integer 
 * numbers N and X, calculates the sum
 * S = 1 + 1!/X + 2!/X2 + … + N!/XN
*/
using System;
using System.Numerics;

class Sum
{
    static void Main()
    {
        int N = 6;
        int X = 2;

        BigInteger squareX = 1;
        BigInteger factorialN = 1;
        decimal Sum = 1;

        for (int i = 1; i <= N; i++)
        {
            factorialN *= i;
            squareX *= X;
            Sum += (decimal)factorialN / X;
        }
        Console.WriteLine(Sum);
    }
}