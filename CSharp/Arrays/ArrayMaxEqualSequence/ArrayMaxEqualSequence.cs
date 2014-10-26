/*Write a program that finds the maximal sequence of equal elements in an array.
		Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1}  {2, 2, 2}.
*/

using System;

class ArrayMaxEqualSequence
{
    static void Main()
    {
        int[] array = { 2, 1, 1, 2, 3, 3, 3, 2, 2, 2, 2, 1 };
        int arrayLength = array.Length;

        int elementsBegin = 0;
        int elementsLength = 1;

        int bestElementsBegin = 0;
        int bestElementsLength = 1;

        //Find max equal sequence
        for (int i = 1; i < arrayLength; i++)
        {
            bool check = (array[i] == array[i - 1]);

            if (check)
            {
                elementsLength++;
            }
            else
            {
                elementsBegin = i;
                elementsLength = 1;
            }

            if (elementsLength > bestElementsLength)
            {
                bestElementsLength = elementsLength;
                bestElementsBegin = elementsBegin;
            }
        }

        //Print max equal sequence
        for (int i = bestElementsBegin; i < (bestElementsBegin + bestElementsLength); i++)
        {

            Console.Write("{0},", array[i]);
        }
        Console.WriteLine();
    }
}
