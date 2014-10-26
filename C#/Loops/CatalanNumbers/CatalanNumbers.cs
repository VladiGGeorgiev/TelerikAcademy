using System;

class CatalanNumbers
{
    static decimal CalculateFactorial(int n) 
    {
        decimal factorial = 1;
        for (int i = 1; i <= n; i++)
        {
            factorial *= i;
        }
        return factorial;
    }

    static void Main()
    {
        int n = 8;

        decimal C = 1;

        C = CalculateFactorial(2 * n) / 
            (CalculateFactorial(n + 1) * CalculateFactorial(n));
        Console.WriteLine(C);
    }
}