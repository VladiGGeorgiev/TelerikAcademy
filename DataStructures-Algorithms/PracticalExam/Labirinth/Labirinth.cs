using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirinth
{
    class Position
    {
        public Position(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
        public int X { get; set; }

        public int Y { get; set; }
        
        public int Z { get; set; }
    }

    class Labirinth
    {
        static Position startPosition;
        static HashSet<Tuple<int, int, int>> forbidden = new HashSet<Tuple<int, int, int>>();
        static char[, ,] matrix;
        static int minSteps = int.MaxValue;
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split(' ');
            startPosition = new Position(int.Parse(line[0]), int.Parse(line[1]), int.Parse(line[2]));

            line = Console.ReadLine().Split(' ');
            int L = int.Parse(line[0]);
            int R = int.Parse(line[1]);
            int C = int.Parse(line[2]);
            matrix = new char[L, R, C];

            for (int i = 0; i < L; i++)
            {
                for (int j = 0; j < R; j++)
                {
                    string row = Console.ReadLine();
                    for (int k = 0; k < C; k++)
                    {
                        matrix[i, j, k] = row[k];   
                    }
                }
            }

            BFS();
            Console.WriteLine(minSteps);
        }

        static void BFS()
        {
            Queue<Tuple<Position, int>> queue = new Queue<Tuple<Position, int>>();
            queue.Enqueue(new Tuple<Position, int>(startPosition, 1));

            forbidden.Add(new Tuple<int,int,int>(startPosition.X, startPosition.Y, startPosition.Z));

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (matrix[current.Item1.X, current.Item1.Y, current.Item1.Z] == 'D')
                {
                    current.Item1.X--;
                    if (current.Item1.X < 0)
                    {
                        if (minSteps > current.Item2)
                        {
                            minSteps = current.Item2;
                        }
                    }
                    else
                    {
                        queue.Enqueue(new Tuple<Position, int>(new Position(current.Item1.X, current.Item1.Y, current.Item1.Z), current.Item2 + 1));
                        forbidden.Add(new Tuple<int, int, int>(current.Item1.X, current.Item1.Y, current.Item1.Z));
                    }
                    
                    current.Item1.X++;
                }

                if (matrix[current.Item1.X, current.Item1.Y, current.Item1.Z] == 'U')
                {
                    current.Item1.X++; 
                    if (current.Item1.X >= matrix.GetLength(0))
                    {
                        if (minSteps > current.Item2)
                        {
                            minSteps = current.Item2;
                        }
                    }
                    else
                    {
                        queue.Enqueue(new Tuple<Position, int>(new Position(current.Item1.X, current.Item1.Y, current.Item1.Z), current.Item2 + 1));
                        forbidden.Add(new Tuple<int, int, int>(current.Item1.X, current.Item1.Y, current.Item1.Z));
                    }
                    
                    current.Item1.X--;
                }

                current.Item1.Y++;
                if (CheckPosition(current.Item1) &&
                    matrix[current.Item1.X, current.Item1.Y, current.Item1.Z] != '#' && 
                    !forbidden.Contains(new Tuple<int, int, int>(current.Item1.X, current.Item1.Y, current.Item1.Z)))
                {
                    queue.Enqueue(new Tuple<Position, int>(new Position(current.Item1.X, current.Item1.Y, current.Item1.Z), current.Item2 + 1));
                    forbidden.Add(new Tuple<int, int, int>(current.Item1.X, current.Item1.Y, current.Item1.Z));
                }
                current.Item1.Y--;

                current.Item1.Y--;
                if (CheckPosition(current.Item1) &&
                    matrix[current.Item1.X, current.Item1.Y, current.Item1.Z] != '#' && !forbidden.Contains(new Tuple<int, int, int>(current.Item1.X, current.Item1.Y, current.Item1.Z)))
                {
                    queue.Enqueue(new Tuple<Position, int>(new Position(current.Item1.X, current.Item1.Y, current.Item1.Z), current.Item2 + 1));
                    forbidden.Add(new Tuple<int, int, int>(current.Item1.X, current.Item1.Y, current.Item1.Z));
                }
                current.Item1.Y++;

                current.Item1.Z++;
                if (CheckPosition(current.Item1) &&
                    matrix[current.Item1.X, current.Item1.Y, current.Item1.Z] != '#' && !forbidden.Contains(new Tuple<int, int, int>(current.Item1.X, current.Item1.Y, current.Item1.Z)))
                {
                    queue.Enqueue(new Tuple<Position, int>(new Position(current.Item1.X, current.Item1.Y, current.Item1.Z), current.Item2 + 1));
                    forbidden.Add(new Tuple<int, int, int>(current.Item1.X, current.Item1.Y, current.Item1.Z));
                }
                current.Item1.Z--;


                current.Item1.Z--;
                if (CheckPosition(current.Item1) &&
                    matrix[current.Item1.X, current.Item1.Y, current.Item1.Z] != '#' && !forbidden.Contains(new Tuple<int, int, int>(current.Item1.X, current.Item1.Y, current.Item1.Z)))
                {
                    queue.Enqueue(new Tuple<Position, int>(new Position(current.Item1.X, current.Item1.Y, current.Item1.Z), current.Item2 + 1));
                    forbidden.Add(new Tuple<int, int, int>(current.Item1.X, current.Item1.Y, current.Item1.Z));
                }
                current.Item1.Z++;
            }
        }

        static bool CheckPosition(Position position)
        {
            if (position.X >= 0 && position.X < matrix.GetLength(0) && 
                position.Y >= 0 && position.Y < matrix.GetLength(1) && 
                position.Z >= 0 && position.Z < matrix.GetLength(2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
