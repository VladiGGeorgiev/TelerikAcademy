/*Write a program to convert binary numbers to their decimal representation.
*/
namespace BinaryToDecimal
{
    using System;
    using System.Linq;

    public class BinaryToDecimal
    {
        public static int BinNumberToDec(string number)
        {
            int decimalNumber = 0;
            int binNumber = int.Parse(number);
            for (int i = 0; i < number.Length; i++)
            {
                decimalNumber += (binNumber % 10) * (int)Math.Pow(2, i);
                binNumber /= 10;
            }

            return decimalNumber;
        }

        public static void Main()
        {
            string binNumber = "10111";
            int decNumber = BinNumberToDec(binNumber);

            Console.WriteLine("Binary number {0} is: {1}", binNumber, decNumber); 
        }
    }
}