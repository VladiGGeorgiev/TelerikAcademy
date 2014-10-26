/*Write a method that reverses the digits of given decimal number. Example: 256  652
*/
using System;
using System.Text;

public class ReverseNumberDigits
{
    public static int ReverseDecimalDigits(int number)
    {
        string stringNumber = number.ToString();
        StringBuilder reversedStringNumber = new StringBuilder();

        for (int i = stringNumber.Length - 1; i >= 0; i--)
        {
            reversedStringNumber.Append(stringNumber[i]);
        }

        int reversedNumber = int.Parse(reversedStringNumber.ToString());
        return reversedNumber;
    }

    public static void Main()
    {
        int number = 531231236;
        Console.WriteLine(number);
        Console.WriteLine(ReverseDecimalDigits(number));
    }
}
