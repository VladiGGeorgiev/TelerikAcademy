/* We are given integer number n, value v (v=0 or 1) and a position p. 
 * Write a sequence of operators that modifies n to hold the value v 
 * at the position p from the binary representation of n.
*/
using System;

class ModifiesNumberBits
{
    static void Main()
    {
        int number = 235;
        byte value = 1;
        byte position = 9;

        Console.WriteLine("{0} in binary: {1}", number, Convert.ToString(number, 2).PadLeft(16,'0'));

        int modifiedNumber = 0;
        if (value == 1)
        {
            modifiedNumber = (number | (1 << position));
        }
        else if (value == 0)
        {
            modifiedNumber = number & (~(1 << position));
        }
        Console.WriteLine("Modified number after put {0} bit at position {1} is: {2}", value, position, modifiedNumber);
        Console.WriteLine("{0} in binary: {1}", modifiedNumber, Convert.ToString(modifiedNumber, 2).PadLeft(16, '0'));
    }
}
