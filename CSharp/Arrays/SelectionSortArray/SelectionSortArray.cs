using System;

public class SelectionSortArray
{
    static void Main()
    {
        int[] array = {11, 6, 4, 3, 11, 9, 2, 5, 10 };

        Print(array); //Print unsorted array
        SelectionSort(array); 
        Print(array); //Print sorted array
    }

    public static void Print(int[] array)
    {
        Console.Write("{ ");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("{0} ", array[i]);
        }
        Console.WriteLine("}");
    }

    public static int[] SelectionSort(int[] array)
    {
        int minElement = 0;
        int temp = 0;
        for (int i = 0; i < array.Length; i++)
        {
            minElement = i;

            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[minElement])
                {
                    minElement = j;
                }
            }

            temp = array[minElement];
            array[minElement] = array[i];
            array[i] = temp;
        }
        return array;
    }
}
