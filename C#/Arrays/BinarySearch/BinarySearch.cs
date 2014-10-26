/*Write a program that finds the index of given element
 * in a sorted array of integers by using the binary 
 * search algorithm (find it in Wikipedia).
*/

using System;

class BinarySearch
{
    private static void BinSearch(int[] array, int searchNumber)
    {
        int middleElement = 0;
        int firstElement = 0;
        int lastElement = array.Length - 1;

        while (firstElement <= lastElement)
        {
            middleElement = (firstElement + lastElement) / 2;

            if (searchNumber < array[middleElement])
            {
                lastElement = middleElement - 1;
            }
            else if (searchNumber > array[middleElement])
            {
                firstElement = middleElement + 1;
            }
            else
            {
                Console.WriteLine("Element {1} found at position: {0}", middleElement, searchNumber);
                break;
            }
        }
    }

    static void Main()
    {
        int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 15, 20 };

        int searchNumber = 15;
        BinSearch(array, searchNumber);
    }
}