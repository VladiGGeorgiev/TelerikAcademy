/*Write a program that compares two char arrays lexicographically (letter by letter).
*/

using System;

class CompareCharArrays
{
    static void Main()
    {
        char[] firstArray = { 'a', 'e', 'c', 'd', 'e' };
        char[] secondArray = { 'a', 's', 'c', 'd', 'e' };

        CharCompare(firstArray, secondArray);
    }

    private static void CharCompare(char[] firstArray, char[] secondArray)
    {
        int length = Math.Min(firstArray.Length, secondArray.Length);
        bool isArraysEqual = true;
        bool isLengthEqual = true;
        string result = "";

        if (firstArray.Length  != secondArray.Length)
        {
		    isLengthEqual = false;
        }

        for (int i = 0; i < length; i++)
        {
            if (firstArray[i] != secondArray[i])
            {
                if (firstArray[i] > secondArray[i])
                {
                    result = "Second array";
                }
                else
                {
                    result = "First array";
                }
                isArraysEqual = false;
                break;
            }
        }

        if (isArraysEqual && isLengthEqual)
        {
            result = "Arrays are equal!";
        }
        else if (!isLengthEqual && result == "")
        {
            if (firstArray.Length > secondArray.Length)
            {
                result = "Second array";
            }
            else
            {
                result = "First array";
            }
        }

        Console.WriteLine(result);
        Print(firstArray);
        Print(secondArray);
    }

    private static void Print(char[] array)
    {
        Console.WriteLine(string.Join(", ", array));
    }
}
