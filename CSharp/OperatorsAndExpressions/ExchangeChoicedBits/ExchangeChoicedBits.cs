/** Write a program that exchanges bits 
 * {p, p+1, …, p+k-1) with bits {q, q+1, …, q+k-1}
 * of given 32-bit unsigned integer.
 */
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int number = 15648566;

        byte p = 3;
        byte q = 28;
        byte k = 3;
        Console.WriteLine("number = {0}\np = {1}\nq = {2}\nk = {3}\n", number, p, q, k);
        Console.WriteLine("Number in binary:\n" + Convert.ToString(number, 2).PadLeft(32, '0'));

        int[] binaryNumber = new int[32];

        for (int i = 0; i < 32; i++)
        {
            binaryNumber[i] = number % 2;
            number /= 2;
        }

        int changeBit = new int();
        for (int i = 0; i < k; i++)
        {
            changeBit = binaryNumber[p];
            binaryNumber[p] = binaryNumber[q];
            binaryNumber[q] = changeBit;
            
            p++;
            q++;
        }

        Console.WriteLine("\nAfter changing bits:");
        for (int i = binaryNumber.Length - 1; i >= 0; i--)
        {
            Console.Write(binaryNumber[i]);
        }
        Console.WriteLine();
    }
     
}