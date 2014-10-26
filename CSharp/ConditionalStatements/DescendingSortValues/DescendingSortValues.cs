using System;

class DescendingSortValues
{
    static void Main(string[] args)
    {
        float a = 60f;
        float b = 48f;
        float c = 49f;

        if (a > b && a > c)
        {
            if (b > c)
            {
                Console.WriteLine("{0} , {1} , {2}", a, b, c);
            }
            else
            {
                Console.WriteLine("{0} , {1} , {2}", a, c, b);
            }
        }
        else if (b > a && b > c)
        {
            if (a > c)
            {
                Console.WriteLine("{0} , {1} , {2}", b, a, c);
            }
            else
            {
                Console.WriteLine("{0} , {1} , {2}", b, c, a);
            }
        }
        else if (c > a && c > b)
        {
            if (a > b)
            {
                Console.WriteLine("{0} , {1} , {2}", c, a, b);
            }
            else
            {
                Console.WriteLine("{0} , {1} , {2}", c, b, a);
            }
        }
        else
        {
            Console.WriteLine("There are same numbers");
        }
    }
}
