/*7.Write a program that reads a number N 
 * and calculates the sum of the first N members 
 * of the sequence of Fibonacci: 
 * 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
*/
using System;

class FibonacciSequenceSum
{
    static void Main()
    {
        Console.Write("Insert N: ");
        int N = int.Parse(Console.ReadLine());

        long fibonacciSum = 0;
        int x = 0;
        int y = 1;
        int next;
        Console.WriteLine(x);
        for (int i = 1; i < N; i++)
        {
            next = x + y;
            x = y;
            y = next;
            fibonacciSum += x;
            Console.WriteLine(x + " ");
        }
        Console.WriteLine("The sum is: " + fibonacciSum);
    }
}