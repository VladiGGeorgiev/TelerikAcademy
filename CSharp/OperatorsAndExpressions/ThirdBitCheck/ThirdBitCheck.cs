/* 5. Write a boolean expression for finding if 
 * the bit 3 (counting from 0) of a given integer is 1 or 0.
*/
using System;

class ThirdBitCheck
{
    static void Main()
    {
        while (true)
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(Convert.ToString(number, 2).PadLeft(16, '0'));
            
            bool check = ((4 & number) == 4);
            if (check)
            {
                Console.WriteLine(check);
            }
            else
            {
                Console.WriteLine(check);
            }
        }
    }
}