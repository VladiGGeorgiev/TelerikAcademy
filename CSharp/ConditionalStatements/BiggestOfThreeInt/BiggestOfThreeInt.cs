using System;

class BiggestOfThreeInt
{
    static void Main()
    {
        int a = 24;
        int b = 26;
        int c = 25;

        if (a > b && a > c)
        {
            Console.WriteLine(a);
        }
        else if (b > a && b > c)
        {
            Console.WriteLine(b);
        }
        else if (c > a && c > b)
        {
            Console.WriteLine(c);
        }
        else
        {
            Console.WriteLine("There are same numbers");
        }
    }
}

