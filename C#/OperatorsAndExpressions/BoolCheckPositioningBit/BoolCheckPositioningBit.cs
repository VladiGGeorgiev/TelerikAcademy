/*10. Write a boolean expression that returns if the bit 
 * at position p (counting from 0) in a given integer number v 
 * has value of 1. Example: v=5; p=1  false.
 */
using System;

class BoolCheckPositioningBit
{
    static void Main()
    {
        int number = 7;
        byte position = 0;

        //bool checkBit = (number >> position) % 2 == 1;
        bool checkBit = ((number >> position) & 1) == 1;
        if (checkBit)
        {
            Console.WriteLine("The {0}nd position of number {1} has bit 1? {2}", position, number, checkBit);
        }
        else
        {
            Console.WriteLine("The {0}nd position of number {1} has bit 1? {2}", position, number, checkBit);
        }

        Console.WriteLine(Convert.ToString(number, 2).PadLeft(16, '0'));
    }
}
