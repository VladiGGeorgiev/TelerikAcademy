using System;
using System.Collections.Generic;
using System.Linq;

namespace Labirinth
{
    public struct Point
    {
        public Point(int row, int col) : this()
	    {
            this.Row = row;
            this.Column = col;
	    }

        public int Row { get; set; }
        public int Column { get; set; }    
    }

    class Program
    {
        static string[,] labirinth =
        {
            {"0", "0", "0", "x", "0", "x"},
            {"0", "x", "0", "x", "0", "x"},
            {"0", "*", "x", "0", "x", "0"},
            {"0", "x", "0", "0", "0", "0"},
            {"0", "0", "0", "x", "x", "0"},
            {"0", "0", "0", "x", "0", "x"},
        };

        static List<Point> directions = new List<Point>()
        {
            new Point(-1, 0),
            new Point(0, 1),
            new Point(1, 0),
            new Point(0, -1)
        };

        static void Main(string[] args)
        {

            var startPosition = FindStartCoord(labirinth);

            BFS(startPosition);

            for (int row = 0; row < labirinth.GetLength(0); row++)
            {
                for (int col = 0; col < labirinth.GetLength(1); col++)
                {
                    if (labirinth[row, col] == "0")
                    {
                        labirinth[row, col] = "u";
                    }
                    Console.Write(labirinth[row, col] + "  ");
                }
                Console.WriteLine();
            }
        }

        private static void BFS(Point startPosition)
        {
            Queue<Tuple<Point, int>> positions = new Queue<Tuple<Point, int>>();
            positions.Enqueue(new Tuple<Point, int>(startPosition, 1));

            while (positions.Count > 0)
            {
                Tuple<Point, int> currentPoint = positions.Dequeue();
                for (int i = 0; i < directions.Count; i++)
                {
                    int newRow = currentPoint.Item1.Row + directions[i].Row;
                    int newCol = currentPoint.Item1.Column + directions[i].Column;

                    if (newRow < 0 || newRow >= labirinth.GetLength(0) ||
                        newCol < 0 || newCol >= labirinth.GetLength(1) || 
                        labirinth[newRow, newCol] == "x")
                    {
                        continue;
                    }

                    Point currentChild = new Point(newRow, newCol);

                    if (labirinth[currentChild.Row, currentChild.Column] == "0")
                    {
                        positions.Enqueue(new Tuple<Point, int>( currentChild, currentPoint.Item2 + 1));
                        labirinth[currentChild.Row, currentChild.Column] = currentPoint.Item2.ToString();
                        
                    }
                }
                //Console.WriteLine(positions.Dequeue().Row + " "+ positions.Dequeue().Row);
            }
        }

        public static Point FindStartCoord(string[,] labirinth)
        {
            Point startPoint = new Point();
            for (int row = 0; row < labirinth.GetLength(0); row++)
            {
                for (int col = 0; col < labirinth.GetLength(1); col++)
                {
                    if (labirinth[row, col] == "*")
                    {
                        startPoint.Row = row;
                        startPoint.Column = col;
                    }
                }    
            }

            return startPoint;
        }
    }
}
