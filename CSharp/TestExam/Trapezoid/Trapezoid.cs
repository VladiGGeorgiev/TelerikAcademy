using System;

class Trapezoid
{
    static void Main()
    {
        int N = short.Parse(Console.ReadLine());

        for (int i = 0; i < N; i++)
        {
            Console.Write(".");
        }
        for (int i = 0; i < N; i++)
        {
            Console.Write("*");
        }
        Console.WriteLine();

        int starIndex = N;
        for (int row = 1; row <= N - 1; row++)
        {
            for (int col = 1; col <= N * 2; col++)
            {
                if (col == starIndex)
                {
                    Console.Write("*");
                    starIndex--;
                }
                else if (col == N * 2)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
        }

        string stars = new String('*', N * 2);
        Console.WriteLine(stars);
        //for (int i = 0; i < N * 2; i++)
        //{
        //    Console.Write("*");
        //}
    }
}