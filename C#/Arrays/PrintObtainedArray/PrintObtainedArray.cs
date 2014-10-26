using System;

class PrintObtainedArray
{
    static void Main()
    {
        int[] array = new int[20];
        for (int i = 0; i <= 19; i++)
        {
            array[i] = i * 5;
        }

        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine(array[i]);
        }
    }
}
