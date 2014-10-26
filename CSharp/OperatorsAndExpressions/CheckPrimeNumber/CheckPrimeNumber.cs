/* 7. Write an expression that checks if given positive 
 * integer number n (n ≤ 100) is prime. E.g. 37 is prime.
 */
using System;

class CheckPrimeNumber
{
    static void Main()
    {
        int number = 36;
        double biggerDividor = Math.Sqrt(number);
        bool primeCheck = true;

        for (int i = 2; i < biggerDividor; i++)
        {
            if (number % i == 0)
            {
                primeCheck = false;
                break;
            }
            primeCheck = true;
        }
        Console.WriteLine(primeCheck);
    }
}
