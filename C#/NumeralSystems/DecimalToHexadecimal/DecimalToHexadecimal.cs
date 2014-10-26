/*Write a program to convert decimal numbers to their hexadecimal representation.
*/

namespace DecimalToHexadecimal
{
    using System;
    using DecimalToBinary;

    public class DecimalToHexadecimal
    {
        public static void Main()
        {
            int number = 500;
            string hexStringNumber = DecNumberToHex(number);

            Console.WriteLine(hexStringNumber);
        }

        private static string DecNumberToHex(int number)
        {
            int remainder = 0;
            string hexStringNumber = string.Empty;
            while (number > 0)
            {
                remainder = number % 16;
                number /= 16;

                switch (remainder)
                {
                    case 10: hexStringNumber += "A";
                        break;
                    case 11: hexStringNumber += "B";
                        break;
                    case 12: hexStringNumber += "C";
                        break;
                    case 13: hexStringNumber += "D";
                        break;
                    case 14: hexStringNumber += "E";
                        break;
                    case 15: hexStringNumber += "F";
                        break;
                    default: hexStringNumber += remainder;
                        break;
                }
            }

            hexStringNumber = DecimalToBinary.StringReverse(hexStringNumber);
            return hexStringNumber;
        }
    }
}
