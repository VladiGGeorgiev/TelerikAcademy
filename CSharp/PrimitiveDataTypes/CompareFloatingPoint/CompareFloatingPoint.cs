using System;

class CompareFloatingPoint
{
    static void Main()
    {
        double firstNumber = 5.00000001;
        double secondNumber = 5.00000001;
        bool numbersCompare = ((secondNumber - firstNumber) < 0.000001);
        Console.WriteLine(numbersCompare);
    }
}