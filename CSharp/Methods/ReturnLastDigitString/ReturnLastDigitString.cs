/*Write a method that returns the last digit of given integer as an English word.
 * Examples: 512  "two", 1024  "four", 12309  "nine".
*/
using System;

class ReturnLastDigitString
{

    static string digitName;
    static void Main()
    {
        Console.WriteLine(LastDigitString(452));
    }

    static string LastDigitString(int a)
    {
        byte check = (byte)(a % 10);
        switch (check)
        {
            case 0: digitName = "Zero";
                break;
            case 1: digitName = "One";
                break;
            case 2: digitName = "Two";
                break;
            case 3: digitName = "Three";
                break;
            case 4: digitName = "Four";
                break;
            case 5: digitName = "Five";
                break;
            case 6: digitName = "Six";
                break;
            case 7: digitName = "Seven";
                break;
            case 8: digitName = "Eight";
                break;
            case 9: digitName = "Nine";
                break;
            default:
                break;
        }
        return digitName;
    }
}

