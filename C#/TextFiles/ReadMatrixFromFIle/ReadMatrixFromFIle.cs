/*Write a program that reads a text file containing a square matrix of numbers and finds in the matrix an area of size 2 x 2 
 * with a maximal sum of its elements. The first line in the input file contains the size of matrix N. 
 * Each of the next N lines contain N numbers separated by space. The output should be a single number in a separate text file. 
 * Example:
4
2 3 3 4
0 2 3 4			17
3 7 1 2
4 3 3 2
*/

namespace ReadMatrixFromFIle
{
    using System;
    using System.IO;

    public class ReadMatrixFromFIle
    {
        private static void WriteFile(int matrixMaxAreaSum)
        {
            using (StreamWriter writer = new StreamWriter("../../result.txt"))
            {
                writer.WriteLine(matrixMaxAreaSum);
            }
        }

        private static int FindMatrixMaxSumArea(int[,] matrix, int areaSize)
        {
            int currentSum = 0;
            int maxSum = int.MinValue;
            for (int i = 0; i <= matrix.GetLength(0) - areaSize; i++)
            {
                for (int j = 0; j <= matrix.GetLength(1) - areaSize; j++)
                {
                    currentSum = matrix[i, j] + matrix[i, (j + 1)] +
                        matrix[(i + 1), j] + matrix[(i + 1), (j + 1)];
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                    }
                }
            }

            return maxSum;
        }

        private static int[,] ReadMatrix()
        {
            using (StreamReader reader = new StreamReader("../../matrix.txt"))
            {
                int n = int.Parse(reader.ReadLine());
                int[,] matrix = new int[n, n];

                string[] tempMatrixLine = new string[n];
                string lineText = reader.ReadLine();
                int line = 0;
                while (lineText != null)
                {
                    tempMatrixLine = lineText.Split(
                        new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    lineText = reader.ReadLine();
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[line, j] = int.Parse(tempMatrixLine[j]);
                    }

                    line++;
                }

                return matrix;
            }
        }

        public static void Main(string[] args)
        {
            int[,] matrix = ReadMatrix();
            int areaSize = 2;

            int matrixMaxAreaSum = FindMatrixMaxSumArea(matrix, areaSize);
            WriteFile(matrixMaxAreaSum);
        }
    }
}
