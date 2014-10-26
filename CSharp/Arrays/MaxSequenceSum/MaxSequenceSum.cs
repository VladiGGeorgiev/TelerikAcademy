using System;

class MaxSequenceSum
{
    static void Main()
    {
        int[] array = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };

        int maxSum = 0;
        int maxSumBegin = 0;
        int maxSumEnd = 0;

        //Finding the max sum
        for (int i = 0; i < array.Length; i++)
        {
            int sum = 0;
            for (int k = i; k < array.Length; k++)
			{
                sum += array[k];

                if (sum > maxSum)
                {
                    maxSum = sum;
                    maxSumBegin = i;
                    maxSumEnd = k;
                }
			}
        }

        //Print the elements
        for (int i = maxSumBegin; i <= maxSumEnd; i++)
        {
            Console.Write(array[i] + " ");
        }
    }
}
