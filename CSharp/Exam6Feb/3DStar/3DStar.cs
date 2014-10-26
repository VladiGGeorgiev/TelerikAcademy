namespace _3DStar
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            string firstLine = Console.ReadLine();
            string[] sizes = firstLine.Split(' ');
            int width = int.Parse(sizes[0]);
            int height = int.Parse(sizes[1]);
            int depth = int.Parse(sizes[2]);

            char[, ,] cube = new char[width, height, depth];
            for (int h = 0; h < height; h++)
            {
                string line = Console.ReadLine();
                string[] tokens = line.Split(' ');
                for (int d = 0; d < depth; d++)
                {
                    for (int w = 0; w < width; w++)
                    {
                        char letter = tokens[d][w];
                        cube[w, h, d] = letter;
                    }
                }
            }

            Dictionary<char, int> stars = FindStarsInCube(cube);
            var list = stars.Keys.ToList();
            list.Sort();

            Print(stars, list);
        }

        private static Dictionary<char, int> FindStarsInCube(char[, ,] cube)
        {
            Dictionary<char, int> stars = new Dictionary<char, int>();

            for (int w = 1; w < cube.GetLength(0) - 1; w++)
            {
                for (int h = 1; h < cube.GetLength(1) - 1; h++)
                {
                    for (int d = 1; d < cube.GetLength(2) - 1; d++)
                    {
                        char color = cube[w, h, d];

                        bool IsStar = (cube[w + 1, h, d] == color) && (cube[w - 1, h, d] == color) &&
                            (cube[w, h + 1, d] == color) && (cube[w, h - 1, d] == color) &&
                            (cube[w, h, d + 1] == color) && (cube[w, h, d - 1] == color);

                        if (IsStar)
                        {
                            char? currentColor = null;
                            for (int i = 0; i < stars.Count; i++)
                            {
                                if (stars.ContainsKey(cube[w, h, d]))
                                {
                                    stars[cube[w, h, d]] += 1;
                                    currentColor = cube[w, h, d];
                                    break;
                                }
                            }

                            if (currentColor == null)
                            {
                                stars.Add(cube[w, h, d], 1);
                            }
                        }
                    }
                }
            }
            return stars;
        }

        private static void Print(Dictionary<char, int> stars, List<char> list)
        {
            int counter = 0;
            foreach (var item in stars)
            {
                counter += item.Value;
            }

            Console.WriteLine(counter);

            foreach (var key in list)
            {
                Console.WriteLine("{0} {1}", key, stars[key]);
            }
        }
    }
}
