/*Write a program that finds the maximal increasing sequence in an array.
 * Example: {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.
*/

using System;

class MaxIncreasingSequence
{
    static void Main()
    {
        int[] array = { 3, 2, 3, 4, 2, 2, 4 };
        int arrayLength = array.Length;

        int elementsBegin = 0;
        int elementsLength = 1;

        int bestElementsBegin = 0;
        int bestElementsLength = 1;

        //Find max increasing sequence
        for (int i = 1; i < arrayLength; i++)
        {
            bool check = (array[i] == array[i - 1] + 1);

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