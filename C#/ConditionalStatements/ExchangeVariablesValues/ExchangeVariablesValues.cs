/* 1.Write an if statement that examines two integer variables
 * and exchanges their values if the first one is greater than the second one.
*/
using System;

class ExchangeVariablesValues
{
    static void Main()
    {
        int a = 6;
        int b = 8;
        Console.WriteLine("a = {0} \nb = {1}\n", a, b);

        a = a + b;
        b = a - b;
        a = a - b;
        Console.WriteLine("a = {0} \nb = {1}", a, b);
    }
}
