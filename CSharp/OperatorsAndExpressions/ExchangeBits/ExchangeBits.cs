/*Write a program that exchanges bits 
 * 3, 4 and 5 with bits 24, 25 and 26 
 * of given 32-bit unsigned integer.
*/
using System;

class ExchangeBits
{
    static void Main()
    {
        Console.Write("Enter unsigned integer: ");
        uint number = uint.Parse(Console.ReadLine());

        string binaryNumber = Convert.ToString(number, 2).PadLeft(32, '0');
        Console.WriteLine(binaryNumber);

        uint getFirstGroup = (number & (7 << 3));
        uint getSecondGroup = (number & (7 << 24));

        number = number & (~getFirstGroup);
        number = number & (~getSecondGroup);

        number = number | (getFirstGroup << 21);
        number = number | (getSecondGroup >> 21);

        binaryNumber = Convert.ToString(number, 2).PadLeft(32, '0');
        Console.WriteLine(binaryNumber);
    }
}
