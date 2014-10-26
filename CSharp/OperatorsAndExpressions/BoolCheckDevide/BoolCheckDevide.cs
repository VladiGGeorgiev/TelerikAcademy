/* 2. Write a boolean expression that checks for 
 * given integer if it can be divided 
 * (without remainder) by 7 and 5 in the same time.
 */
using System;

class BoolCheckDevide
{
    static void Main()
    {
        Console.Write("Insert a number:");
        int number = int.Parse(Console.ReadLine());
        bool check;

        if ((number % 7 == 0) && (number % 5 == 0))
        {
            check = true;
            Console.WriteLine("Is number divide by 7 and 5: {0}", check);
        }
        else
        {
            check = false;
            Console.WriteLine("Is number divide by 7 and 5: {0}", check);
        }
    }
}
