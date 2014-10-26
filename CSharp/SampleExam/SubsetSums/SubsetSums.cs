using System;

class SubsetSums
{
    static void Main()
    {
        long S = long.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());
        long[] numbers = new long[N];
        for (int i = 0; i < N; i++)
        {
            numbers[i] = long.Parse(Console.ReadLine());
        }

        int maxBitNumber = 1;
        for (int i = 0; i < N; i++)
        {
            maxBitNumber *= 2;
        }

        int sumCounter = 0;
        for (int i = 1; i < maxBitNumber; i++)
        {
            long currentSum = 0;
            for (int j = 0; j < N; j++)
            {
                int mask = 1 << j;
                int iAndMask = i & mask;
                int bit = iAndMask >> j;
                if (bit == 1) currentSum += numbers[j];
            }
            if (currentSum == S)
            {
                sumCounter++;
            }
            currentSum = 0;
        }
        Console.WriteLine(sumCounter);
    }
}