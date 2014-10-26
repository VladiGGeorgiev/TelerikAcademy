using System;

class ForestRoad
{
    static void Main()
    {
        short N = short.Parse(Console.ReadLine());
        int position = 2;

        for (int row = 0; row < (2 * N - 1); row++)
        {
            for (int col = 0; col < N; col++)
            {
                if (col == row)
                {
                    Console.Write("*");
                }

                else if (row >= N)
                {
                    if (col == row - position)
                    {
                        Console.Write("*");
                        position += 2;
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }

                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
        }
    }
}
