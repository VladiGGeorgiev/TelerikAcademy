using System;

class AssignNullValues
{
    static void Main(string[] args)
    {
        int? nullInt = null;
        double? nullDouble = null;
        Console.WriteLine(nullInt);
        Console.WriteLine(nullDouble);
        int? a = 5;
        double? b = 1;
        Console.WriteLine(a);
        Console.WriteLine(b);
    }
}