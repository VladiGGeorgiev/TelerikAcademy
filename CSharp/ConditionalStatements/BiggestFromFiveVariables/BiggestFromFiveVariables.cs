using System;

class BiggestFromFiveVariables
{
    static void Main()
    {
        int a = 8;
        int b = 22;
        int c = 21;
        int d = 20;
        int e = 15;

        if (a > b && a > c && a > d && a > e)
        {
            Console.WriteLine(a);
        }
        else if (b > a && b > c && b > d && b > e)
        {
            Console.WriteLine(b);
        }
        else if (c > b && c > a && c > d && c > e)
        {
            Console.WriteLine(c);
        }
        else if (d > a && d > b && d > c && d > e)
        {
            Console.WriteLine(d);
        }
        else if (e > a && e > b && e > c && e > d)
        {
            Console.WriteLine(e);
        }
    }
}
