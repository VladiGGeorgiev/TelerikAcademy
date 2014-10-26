using System;

class SpiralMatrix
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        int[,] array = new int[number, number];

        int digits = 1;

        int currentRow = 0;
        int currentCol = 0;
        int maxRow = number - 1;
        int maxCol = number - 1;

        while (digits <= number * number)
        {
            for (int i = currentCol; i <= maxCol; i++)
            {
                array[currentRow, i] = digits;
                digits++;
            }
            currentRow++;
            for (int i = currentRow; i <= maxRow; i++)
            {
                array[i, maxCol] = digits;
                digits++;
            }
            maxCol--;
            for (int i = maxCol; i >= currentCol; i--)
            {
                array[maxRow, i] = digits;
                digits++;
            }
            maxRow--;
            for (int i = maxRow; i >= currentRow; i--)
            {
                array[i, currentCol] = digits;
                digits++;
            }
            currentCol++;
        }

        for (int rows = 0; rows < array.GetLength(0); rows++)
        {
            for (int cols = 0; cols < array.GetLength(1); cols++)
            {
                Console.Write("{0:d2} ", array[rows, cols]);
            }
            Console.WriteLine();
        }
    }
}
