/* 4. Write an expression that checks for given integer 
 * if its third digit (right-to-left) is 7. E. g. 1732  true.
*/
using System;

class ThirdNumberCheck
{
    static void Main()
    {
        Console.Write("Insert a number:");
        int number = int.Parse(Console.ReadLine());

        number = number / 100;
        int check = number % 10;
        if (check == 7)
        {
            Console.WriteLine("Third number from right side is seven.");
        }
        else
        {
            Console.WriteLine("Third number from right is NOT seven.");
        }
    }
}
