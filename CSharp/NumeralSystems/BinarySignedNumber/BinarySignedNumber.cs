/*Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short).
*/

namespace BinarySignedNumber
{
    using System;

    class BinarySignedNumber
    {
        static void Main()
        {
            short number = short.Parse(Console.ReadLine());
            string binNumber = ConvertSignedNumberToBinary(number);
            Console.WriteLine(binNumber);
        }

        private static string ConvertSignedNumberToBinary(short number)
        {
            string binaryNumber = string.Empty;
            //Get bits of number one by one
            for (int i = 15; i >= 0; i--)
            {
                binaryNumber += (number >> i) & 1;
            }

            return binaryNumber;
        }
    }
}
