namespace Refactoring
{
    using System;

    class Program
    {
        private static int ReadMatrixSize(int maxSize)
        {
            string input;
            int size;

            do
            {
                Console.WriteLine("Enter n, the size of the matrix (0 < n <= {0}):", maxSize);
                input = Console.ReadLine();
            }
            while (!int.TryParse(input, out size) || size < 1 || size > maxSize);

            return size;
        }

        private static void Main()
        {
            int size = ReadMatrixSize(Matrix.MaxSize);

            Matrix matrix = new Matrix(size);

            matrix.Traverse();

            Console.WriteLine(matrix);
        }
    }
}
