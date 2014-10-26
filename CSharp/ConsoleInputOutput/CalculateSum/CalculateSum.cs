/*Write a program to calculate the sum 
 * (with accuracy of 0.001): 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...
*/
using System;

class CalculateSum
{
    static void Main()
    {
        decimal sum = 1.0m;
        for (int i = 2; i < 1 / 0.001; i++)
        {
            if (i % 2 == 0)
            {
                sum = sum + (decimal)1 / i;
            }
            else
            {
                sum = sum - (decimal)1 / i;
            }
        }
        Console.WriteLine("The sum is: {0:0.000000000000}", sum);
    }
}
