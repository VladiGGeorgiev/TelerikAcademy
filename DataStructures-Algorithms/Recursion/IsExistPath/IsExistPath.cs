using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsExistPath
{
    class IsExistPath
    {
        static char[,] matrix = new char[100, 100];

        static int[,] directions = new int[4, 2]
        {
            {1, 0},
            {0, 1},
            {-1, 0},
            {0, -1},
        };

        static bool isExistPath = false;

        static void Main(string[] args)
        {
            InitializeMatrix();

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
            Console.WriteLine("Is there a path: " + isExistPath);
        }

        private static void InitializeMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = ' ';   
                }
            }
        }

        private static void TraverseMatrix(int row, int col)
        {
            if (isExistPath || 
                row < 0 || col < 0 || 
                row >= matrix.GetLength(0) || 
                col >= matrix.GetLength(1))
            {
                return;
            }

            if (matrix[row, col] == 'X')
            {
                isExistPath = true;
                return;
            }

            if (matrix[row, col] != ' ')
            {
                return;
            }

            matrix[row, col] = 'v';

            for (int i = 0; i < directions.GetLength(0); i++)
            {
                TraverseMatrix(row + directions[i, 0], col + directions[i, 1]);
            }

            matrix[row, col] = ' ';
        }
    }
}
