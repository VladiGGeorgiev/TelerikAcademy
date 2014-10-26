using System;

class PrimeNumbers
{
    static void Main()
    {

        int[] array = new int[100];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = i + 1;
        }


        for (int i = 1; i < array.Length; i++)
        {
            for (int j = 2; j <= array.Length / (i + 1); j++)
            {
                array[(j * (i + 1)) - 1] = 0;
            }
        }


        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] != 0)
            {
                Console.Write("{0}, ",array[i]);
            }
        }
           

    }
}