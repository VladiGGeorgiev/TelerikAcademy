using System;

class MatrixTriangle
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];

        int number = 1;
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col <= row; col++)
            {
                matrix[(n - 1 - row + col), col] = number;
                number++;
            }
        }

        Print(matrix);
    }

    private static void Print(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0:d2} ", matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}
/*
 
 * 0 0 1 2 3 4 5 6
 * 0 
 * 1 7 
 * 2 4 8
 * 3 2 5 9
 * 4 1 3 6 10
 * 5 
 * 6
 
 
 
 
 
 */