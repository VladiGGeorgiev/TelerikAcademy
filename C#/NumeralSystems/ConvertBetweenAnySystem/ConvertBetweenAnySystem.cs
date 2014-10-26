/*Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤  16).
*/

namespace ConvertBetweenAnySystem
{
    using System;
    using DecimalToBinary;

    class ConvertBetweenAnySystem
    {
        private static string ConvertFromDecimalSystem(int decimalNumber, int toBase)
        {
            int remainder = 0;
            string toBaseStringNumber = string.Empty;
            while (decimalNumber > 0)
            {
                remainder = decimalNumber % toBase;
                decimalNumber /= toBase;

                switch (remainder)
                {
                    case 10: toBaseStringNumber += "A";
                        break;
                    case 11: toBaseStringNumber += "B";
                        break;
                    case 12: toBaseStringNumber += "C";
                        break;
                    case 13: toBaseStringNumber += "D";
                        break;
                    case 14: toBaseStringNumber += "E";
                        break;
                    case 15: toBaseStringNumber += "F";
                        break;
                    default: toBaseStringNumber += remainder;
                        break;
                }
            }

            toBaseStringNumber = DecimalToBinary.StringReverse(toBaseStringNumber);
            return toBaseStringNumber;
        }

        private static int ConverToDecimalSystem(string number, int fromBase)
        {
            int decimalNumber = 0;

            for (int i = 0; i < number.Length; i++)
            {
                decimalNumber += Convert.ToInt32(number.Substring(i, 1)) * (int)Math.Pow(fromBase, number.Length - 1 - i);
            }

            return decimalNumber;
        }

        static void Main()
        {
            Console.Write("From which system do you want do convert: ");
            int s = int.Parse(Console.ReadLine());
            Console.Write("To which system do you want do convert: ");
            int d = int.Parse(Console.ReadLine());
            string number = Console.ReadLine();

            int decimalNumber = ConverToDecimalSystem(number, s);
            Console.WriteLine(ConvertFromDecimalSystem(decimalNumber, d));
        }
    }
}
