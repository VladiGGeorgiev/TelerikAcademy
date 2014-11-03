using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestEmptyArea
{
    class LargestEmptyArea
    {
        static char[,] matrix =
        {
            {'O', 'O', 'O', '*', 'O', 'O', 'O', '*', 'O', 'O'},
            {'*', '*', 'O', '*', 'O', '*', 'O', '*', '*', '*'},
            {'O', 'O', 'O', '*', 'O', 'O', 'O', '*', 'O', 'O'},
            {'*', '*', '*', '*', '*', '*', '*', '*', 'O', '*'},
            {'O', 'O', 'O', '*', 'O', 'O', 'O', '*', 'O', 'O'},
        };

        static int[,] directions = new int[4, 2]
        {
            {1, 0},
            {0, 1},
            {-1, 0},
            {0, -1},
        };

        static int maxPathLength = 0;

        static void Main(string[] args)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'O')
                    {
                        TraverseMatrix(row, col, 0);
                    }
                }
            }

            PrintMatrix();
            Console.WriteLine("Max path length: " + maxPathLength);
        }

        private static void TraverseMatrix(int row, int col, int pathLength)
        {
            if (row < 0 || col < 0 ||
                row >= matrix.GetLength(0) ||
                col >= matrix.GetLength(1))
            {
                return;
            }

            if (matrix[row, col] != 'O')
            {
                return;
            }

            matrix[row, col] = 'v';
            pathLength++;

            for (int i = 0; i < directions.GetLength(0); i++)
            {
                TraverseMatrix(row + directions[i, 0], col + directions[i, 1], pathLength);
            }

            matrix[row, col] = 'O';

            if (pathLength > maxPathLength)
            {
                maxPathLength = pathLength;
            }
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
