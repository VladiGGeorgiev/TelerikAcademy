using System;

class MathExpression
{
    static void Main()
    {
        decimal N = decimal.Parse(Console.ReadLine());
        decimal M = decimal.Parse(Console.ReadLine());
        decimal P = decimal.Parse(Console.ReadLine());

        decimal a = 0;
        decimal b = 0;
        decimal c = 0;

        a = N * N + 1 / (M * P) + 1337;
        b = N - (128.523123123m * P);
        c = (decimal)Math.Sin((int)M % 180);

        decimal result = a / b + c;
        Console.WriteLine("{0:f6}", result);
    }
}