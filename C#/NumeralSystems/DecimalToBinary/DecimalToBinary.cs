// Write a program to convert decimal numbers to their binary representation.

namespace DecimalToBinary
{
    using System;
    using System.Linq;

    public static class DecimalToBinary
    {
        public static string DecNumberToBin(int number)
        {
            int remainder = 0;
            string binStringNumber = string.Empty;

            while (number > 0)
            {
                remainder = number % 2;
                number /= 2;
                binStringNumber += remainder;
            }

            binStringNumber = StringReverse(binStringNumber);
            return binStringNumber;
        }

        public static string StringReverse(string binStringNumber)
        {
            string reversedString = string.Empty;

            for (int i = 0; i < binStringNumber.Length; i++)
            {
                reversedString += binStringNumber[(binStringNumber.Length - 1) - i];
            }

            return reversedString;
        }

        public static void Main(string[] args)
        {
            int number = 8;
            Console.WriteLine(DecNumberToBin(number));
        }
    }
}
