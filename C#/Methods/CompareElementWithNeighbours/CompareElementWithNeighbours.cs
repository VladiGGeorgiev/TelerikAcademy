/*Write a method that checks if the element at given position in given array
 * of integers is bigger than its two neighbors (when such exist).
*/
using System;

class CompareElementWithNeighbours
{
    static bool CompareWithNeighbours(int elementPosition, params int[] array)
    {
        bool check = true;
        if (elementPosition == 0)
        {
            check = array[elementPosition] > array[elementPosition + 1];
        }
        else if (elementPosition == (array.Length - 1))
        {
            check = array[elementPosition] > array[elementPosition - 1];
        }
        else
        {
            check = array[elementPosition] > array[elementPosition - 1] &&
                array[elementPosition] > array[elementPosition + 1];
        }

        return check;
    }

    static void Main()
    {
        int[] array = { 13, 2, 5, 9, 6, 3, 1, 4, 7, 15, 2, 36 };
        int elementPosition = 2;

        Console.WriteLine("Is element bigger than his neighbours: {0}", 
            CompareWithNeighbours(elementPosition, array));
    }
}
