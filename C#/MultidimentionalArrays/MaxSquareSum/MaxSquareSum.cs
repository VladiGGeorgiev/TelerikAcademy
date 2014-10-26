using System;

class MaxSquareSum
{
    private static void ConsoleRead(int size, int[,] matrix)
    {
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                Console.Write("matrix[{0}, {1}]: ", row, col);
                matrix[row, col] = int.Parse(Console.ReadLine());
            }
        }
    }

    private static void Print(int size, int[,] matrix)
    {
        for (int i = 0; i < size; i++)
        {
            for (int k = 0; k < size; k++)
            {
                Console.Write("{0} ", matrix[i, k]);
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        int[,] matrix = new int[size, size];

        ConsoleRead(size, matrix);

        Print(size, matrix);

        int maxSum = 0;
        int maxCol = 0;
        int maxRow = 0;
        for (int row = 0; row <= size - 3; row++)
        {
            int sum = 0;
            for (int col = 0; col <= size - 3; col++)
            {
                sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                    + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                    + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                if (sum > maxSum)
                {
                    maxSum = sum;
                    maxCol = col;
                    maxRow = row;
                }
            }
        }

        for (int i = maxRow; i < maxRow + 3; i++)
        {
            for (int k = maxCol; k < maxCol + 3; k++)
            {
                Console.Write("{0} ", matrix[i, k]);
            }
            Console.WriteLine();
        }
    }
}