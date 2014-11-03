using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AllPassableAreas
{
    class AllPassableAreas
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

        static void Main(string[] args)
        {
            Console.WriteLine("Insert out cell: row,col");
            string[] exit = Console.ReadLine().Split(',');
            int outRow = int.Parse(exit[0]);
            int outCol = int.Parse(exit[1]);
            matrix[outRow, outCol] = 'X';

            Console.WriteLine("Insert start cell: x,y");
            string[] begin = Console.ReadLine().Split(',');
            int beginRow = int.Parse(begin[0]);
            int beginCol = int.Parse(begin[1]);

            TraverseMatrix(beginRow, beginCol);
        }

        private static void TraverseMatrix(int row, int col)
        {
            if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                return;
            }

            if (matrix[row, col] == 'X')
            {
                Console.WriteLine("Exit at [{0},{1}]", row, col);
                PrintMatrix();
                return;
            }

            if (matrix[row, col] != 'O')
            {
                return;
            }

            matrix[row, col] = 'v';

            for (int i = 0; i < directions.GetLength(0); i++)
            {
                TraverseMatrix(row + directions[i, 0], col + directions[i, 1]);
            }

            matrix[row, col] = 'O';
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
