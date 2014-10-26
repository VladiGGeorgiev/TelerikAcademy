/*Write a program to convert binary numbers to hexadecimal numbers (directly).
*/
namespace BinaryToHexadecimal
{
    using System;

    public class BinaryToHexadecimal
    {
        public static void Main()
        {
            string binNumber = "1111111001111";

            BinToHexNumber(binNumber);
        }

        private static void BinToHexNumber(string binNumber)
        {
            //Add zeros to left side
            binNumber = new string('0', 4 - (binNumber.Length % 4)) + binNumber;
            Console.WriteLine(binNumber);

            string hexNumber = string.Empty;
            //Gets four by four bits and convert it to Hexadecimal representation
            for (int i = 0; i <= binNumber.Length - 4; i += 4)
            {
                string subString = binNumber.Substring(i, 4);
                switch (subString)
                {
                    case "0000": hexNumber += '0';
                        break;
                    case "0001": hexNumber += '1';
                        break;
                    case "0010": hexNumber += "2";
                        break;
                    case "0011": hexNumber += "3";
                        break;
                    case "0100": hexNumber += "4";
                        break;
                    case "0101": hexNumber += "5";
                        break;
                    case "0110": hexNumber += "6";
                        break;
                    case "0111": hexNumber += "7";
                        break;
                    case "1000": hexNumber += "8";
                        break;
                    case "1001": hexNumber += "9";
                        break;
                    case "1010": hexNumber += "A";
                        break;
                    case "1011": hexNumber += "B";
                        break;
                    case "1100": hexNumber += "C";
                        break;
                    case "1101": hexNumber += "D";
                        break;
                    case "1110": hexNumber += "E";
                        break;
                    case "1111": hexNumber += "F";
                        break;
                }
            }

            Console.WriteLine(hexNumber);
        }
    }
}
