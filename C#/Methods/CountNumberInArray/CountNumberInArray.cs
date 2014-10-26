/*Write a method that counts how many times given number appears in given array. 
 * Write a test program to check if the method is working correctly.
*/
using System;

class CountNumberInArray
{
    static void Main()
    {
        int[] array = {1,2,3,4,2,1,23,4,3,2,1,3,4,2};
        int number = 2;

        Console.WriteLine("The number {0} repeats {1} times.", 
            number, CountNumberArray(number, array));
    }

    static int CountNumberArray(int number, params int[] array)
    {
        int arrayLength = array.Length;
        int numberCounter = 0;
        for (int i = 0; i < arrayLength; i++)
        {
            if (number == array[i])
            {
                numberCounter++;
            }
        }
        return numberCounter;
    }
}
