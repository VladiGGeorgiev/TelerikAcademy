using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slices3D
{
    class Slices3D
    {
        static void Main(string[] args)
        {
            string strSizes = Console.ReadLine();
            string[] sizes = strSizes.Split(' ');
            
            int width = int.Parse(sizes[0]);
            int height = int.Parse(sizes[1]);
            int depth = int.Parse(sizes[2]);

            int[, ,] cube = new int[width, height, depth];

            long totalSum = 0;
            for (int h = 0; h < height; h++)
            {
                string line = Console.ReadLine();
                string[] tokens = line.Split('|');
                for (int d = 0; d < depth; d++)
                {
                    string[] numbers = tokens[d].Trim().Split(
                        new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
                    for (int w = 0; w < width; w++)
                    {
                        int value = int.Parse(numbers[w]);
                        cube[w,h,d] = value;
                        totalSum += cube[w, h, d];
                    }
                }
            }

            long currentSum = 0;
            int sumsCounter = 0;
            for (int w = 0; w < width -1; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    for (int d = 0; d < depth; d++)
                    {
                        currentSum += cube[w, h, d];
                    }
                }
                if (currentSum*2 == totalSum)
                {
                    sumsCounter++;
                }
            }

            currentSum = 0;
            for (int h = 0; h < height -1; h++)
            {
                for (int w = 0; w < width; w++)
                {
                    for (int d = 0; d < depth; d++)
                    {
                        currentSum += cube[w, h, d];
                    }
                }
                if (currentSum * 2 == totalSum)
                {
                    sumsCounter++;
                }
            }

            currentSum = 0;
            for (int d = 0; d < depth - 1; d++)
            {
                for (int w = 0; w < width; w++)
                {
                    for (int h = 0; h < height; h++)
                    {
                        currentSum += cube[w, h, d];
                    }
                }

                if (currentSum * 2 == totalSum)
                {
                    sumsCounter++;
                }
            }

            Console.WriteLine(sumsCounter);
        }
    }
}
