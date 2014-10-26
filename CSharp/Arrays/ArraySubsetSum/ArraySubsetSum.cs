using System;
/** We are given an array of integers and a number S. 
 *  Write a program to find if there exists a subset of 
 *  the elements of the array that has a sum S. Example:
	arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14  yes (1+2+5+6)
*/

class ArraySubsetSum
{
    static void Main()
    {
        int[] array = new int[] {2, 1, 2, 4, 3, 5, 2, 6};
        int sum = 14;

        int subsets = NumberOfSubsets(array);

        for (int number = 1; number < subsets; number++)
        {
            int currentSum = 0;
            for (int element = 0; element < array.Length; element++ )
            {
                int bit = GetBitsFromNumber(number, element);

                if (bit == 1)   currentSum += array[element];
            }

            if (currentSum == sum)
            {
                PrintSubsetNumbers(array, number);
                break;
            }
        }
    }

    private static void PrintSubsetNumbers(int[] array, int i)
    {
        Console.Write("Yes { ");
        int bit = 0;
        for (int k = 0; k < array.Length; k++)
        {
            bit = GetBitsFromNumber(i, k);

            if (bit == 1) Console.Write("{0} ", array[k]);
        }
        Console.WriteLine("}");
    }

    private static int NumberOfSubsets(int[] array)
    {
        int subsets = 1;
        for (int i = 0; i < array.Length; i++)
        {
            subsets *= 2;
        }
        return subsets;
    }

    private static int GetBitsFromNumber(int i, int j)
    {
        int mask = 1 << j;
        int maskAndI = mask & i;
        maskAndI = maskAndI >> j;

        return maskAndI;
    }
}