using System;
using System.Numerics;

class FactorialZeros
{
    static void Main()
    {
        int N = 15;
        BigInteger factorial = 1;

        for (int i = 1; i <= N; i++)
        {
            factorial *= i;
        }

        Console.WriteLine("Factorial is: {0}", factorial);

        BigInteger zeros = 0;
        int countZeros = 0;

        while (true)
        {
            zeros = factorial % 10;
            if (zeros != 0)
            {
                break;
            }
            factorial = factorial / 10;
            countZeros++;
        }
        Console.WriteLine("There are {0} zeros", countZeros);
    }
}