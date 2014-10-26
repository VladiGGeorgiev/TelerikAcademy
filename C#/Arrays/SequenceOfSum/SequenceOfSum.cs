using System;

class SequenceOfSum
{
    static void Main()
    {
        int[] array = { 4, 3, 1, 4, 2, 5, 8 };
        int arrayLength = array.Length;
        int S = 11;

        int elementsBegin = 0;
        int elementsEnd = 0;

        for (int i = 0; i < arrayLength; i++)
        {
            int sum = 0;
            for (int k = i; k < arrayLength; k++)
            {
                sum += array[k];
                if (sum == S)
                {
                    elementsBegin = i;
                    elementsEnd = k;
                    break;
                }
            }
        }

        for (int i = elementsBegin; i <= elementsEnd; i++)
        {
            Console.Write(array[i] + " ");
        }
    }
}