/*Write a program that reads two integer numbers N and K and an array of N elements 
 * from the console. Find in the array those K elements that have maximal sum.
*/

using System;

class MaxArraySum
{
    private static void ReadArray(int n, int[] array)
    {
        for (int element = 0; element < n; element++)
        {
            array[element] = int.Parse(Console.ReadLine());
        }
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        int[] array = new int[n];

        ReadArray(n, array);

        int maxSum = 0;
        int currentSum = 0;
        int maxSumBegin = 0;
        for (int i = 0; i < array.Length - k + 1; i++)
        {
            for (int j = i; j < k + i; j++)
            {
                currentSum += array[j];
            }
            if (currentSum > maxSum)
            {
                maxSum = currentSum;
                maxSumBegin = i;
            }
            currentSum = 0;
        }
        Console.WriteLine(maxSum);
        for (int i = maxSumBegin; i < maxSumBegin + k; i++)
        {
            Console.Write("{0}, ", array[i]);
        }
    }
}