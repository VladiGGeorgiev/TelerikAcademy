using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AllPathsInMatrix
{
    class Position
    {
        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public override string ToString()
        {
            return "(" + this.Row + " " + this.Col + ")";
        }
    }

    class AllPathsInMatrix
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
        static List<Position> path;

        static void Main(string[] args)
        {
            PrintMatrix();
            Console.WriteLine(Environment.NewLine + "Paths:");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'O')
                    {
                        path = new List<Position>();
                        TraverseMatrix(row, col, 0);

                        Console.WriteLine(string.Join(" -> ", path) + Environment.NewLine);
                    }
                }
            }
        }

        private static void TraverseMatrix(int row, int col, int pathLength)
        {
            if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                return;
            }
            
            if (matrix[row, col] != 'O')
            {
                return;
            }

            matrix[row, col] = 'v';
            path.Add(new Position(row, col));

            for (int i = 0; i < directions.GetLength(0); i++)
            {
                TraverseMatrix(row + directions[i, 0], col + directions[i, 1], pathLength);
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
