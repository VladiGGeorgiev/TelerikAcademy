/*Write a program to print the first 100 members of the sequence 
 * of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
*/
using System;

class FibonacciSequence
{
    static void Main()
    {
        uint a = 0u;
        uint b = 1u;
        uint nextNumber = new uint();

        Console.WriteLine(a);
        Console.WriteLine(b);
        for (int i = 0; i < 100; i++)
        {
            nextNumber = a + b;
            a = b;
            b = nextNumber;
            Console.WriteLine(nextNumber);
        }

        //With memorization and Recursion

    }
    public static int[] holder;

    static int Fibonacci(int n, int[] holder)
    {
        if (holder[n] != 0)
        {
            return holder[n];
        }
        if (n == 0)
        {
            return 0;
        }
        if (n == 1)
        {
            return 1;
        }
        holder[n] = Fibonacci(n - 1, holder) + Fibonacci(n - 2, holder);
        return holder[n];
    }
}
