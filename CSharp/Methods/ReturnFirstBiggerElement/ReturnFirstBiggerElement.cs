/*Write a method that returns the index of the first element in array 
 * that is bigger than its neighbors, or -1, if there’s no such element.
Use the method from the previous exercise.
*/

using System;

class ReturnFirstBiggerElement
{
    static void Main(string[] args)
    {
        int[] array = { 1, 2, 5, 5, 6, 8, 18, 14, 17, 19, 20, 21 };
        Console.WriteLine(FirstBiggerElementPosition(array));
    }

    static int FirstBiggerElementPosition(params int[] array)
    {
        bool check = false;
        int arrayLength = array.Length;
        for (int i = 1; i < arrayLength - 1; i++)
        {
            check = (array[i] > array[i - 1]) && (array[i] > array[i + 1]);

            if (check)
            {
                return i;
                break;
            }
        }
        return -1;
    }
}
