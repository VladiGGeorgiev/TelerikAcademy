/*Write a program that reads two arrays from the 
 * console and compares them element by element.
*/

using System;

class CompareArrays
{
    static void Main()
    {
        int p = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        int[] firstArray = new int[n];
        int[] secondArray = new int[p];

        //Read the arrays from console
        for (int i = 0; i < firstArray.Length; i++)
        {
            firstArray[i] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < secondArray.Length; i++)
        {
            secondArray[i] = int.Parse(Console.ReadLine());
        }

        bool matchChecker = true;

        //Array length check
        if (firstArray.Length == secondArray.Length)
        {
            //Compares element by element
            for (int i = 0; i < p; i++)
            {
                if (firstArray[i] != secondArray[i])
                {
                    matchChecker = false;
                    break;
                }
                else
                {
                    matchChecker = true;
                }
            }
        }
        else
        {
            matchChecker = false;
        }
        Console.WriteLine(matchChecker);
    }
}
