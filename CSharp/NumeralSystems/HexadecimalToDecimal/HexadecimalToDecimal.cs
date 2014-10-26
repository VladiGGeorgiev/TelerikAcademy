/* Write a program to convert hexadecimal numbers to their decimal representation.
*/

namespace HexadecimalToDecimal
{
    using System;
    using DecimalToBinary;

    public class HexadecimalToDecimal
    {
        public static void Main(string[] args)
        {
            string hexStringNumber = "A7B1";
            int decNumber = HexToDecNumber(hexStringNumber);

            Console.WriteLine("Number {0} in decimal system is: {1}", hexStringNumber, decNumber);
        }

        private static int HexToDecNumber(string hexStringNumber)
        {
            hexStringNumber = DecimalToBinary.StringReverse(hexStringNumber);
            hexStringNumber = hexStringNumber.ToUpper();

            int digit = 0;
            int decNumber = 0;
            for (int i = 0; i < hexStringNumber.Length; i++)
            {
                switch (hexStringNumber[i])
                {
                    case 'A': digit = 10;
                        break;
                    case 'B': digit = 11;
                        break;
                    case 'C': digit = 12;
                        break;
                    case 'D': digit = 13;
                        break;
                    case 'E': digit = 14;
                        break;
                    case 'F': digit = 15;
                        break;
                    default: digit = hexStringNumber[i] - '0';
                        break;
                }

                decNumber += digit * (int)Math.Pow(16, i);
            }

            return decNumber;
        }
    }
}
