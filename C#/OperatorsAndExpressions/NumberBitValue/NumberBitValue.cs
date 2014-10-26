/*  11. Write an expression that extracts 
 * from a given integer i the value of a given bit number b. 
 * Example: i=5; b=2  value=1.
 */
using System;

class NumberBitValue
{
    static void Main()
    {
        int number = 12;
        int position = 2;

        int bitValue = (number >> position) % 2;
        Console.WriteLine("Bit of position {0} of number {1} is: {2}", position, number, bitValue);
        Console.WriteLine(Convert.ToString(number, 2).PadLeft(16, '0'));
    }
}
