using System;

class MatrixSpiral
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        int[,] matrix = new int[size, size];

        FillSpiralMatrix(matrix, size);

        Print(matrix);
    }

    private static void FillSpiralMatrix(int[,] matrix, int n)
    {
        int number = 1;
        int currentCol = 0;
        int currentRow = 0;
        int maxRow = n - 1;
        int maxCol = n - 1;

        while (number <= (n * n))
        {
            for (int row = currentRow; row <= maxRow; row++)
            {
                matrix[row, currentCol] = number;
                number++;
            }
            currentCol++;
            for (int col = currentCol; col <= maxCol; col++)
            {
                matrix[maxRow, col] = number;
                number++;
            }
            maxRow--;

            for (int row = maxRow; row >= currentRow; row--)
            {
                matrix[row, maxCol] = number;
                number++;
            }
            maxCol--;

            for (int col = maxCol; col >= currentCol; col--)
            {
                matrix[currentRow, col] = number;
                number++;
            }
            currentRow++;
        }
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