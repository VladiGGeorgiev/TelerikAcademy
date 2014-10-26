using System;

class Permutations
{
    private static int[] FillArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = i + 1;
        }
        return array;
    }

    private static void PermutateArray(int[] array, int N, int currentElement)
    {
        if (currentElement == (array.Length - 1))
        {
            PrintArray(array);
        }
        else
        {
            for (int i = currentElement; i < N; i++)
            {
                //TODO: Complete the recursion
            }
        }
    }

    private static void PrintArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("{0} ", array[i]);
        }
        Console.WriteLine();
    }

    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        int[] array = new int[N];

        FillArray(array);
        PermutateArray(array, N, 0);
    }


}