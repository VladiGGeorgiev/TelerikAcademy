using System;

class PrintMatrix
{
    static void Main()
    {
        int N = 5;
        for (int i = 0; i < N; i++)
        {
            for (int j = i + 1; j <= N + i; j++)
            {
                Console.Write(j + " ");
            }
            Console.WriteLine();
        }
    }
}
