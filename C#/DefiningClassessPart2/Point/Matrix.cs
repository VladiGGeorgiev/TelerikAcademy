namespace Point
{
    using System;
    using System.Collections.Generic;

    class Matrix<T> where T : IEnumerable<T>
    {
        private readonly T[,] matrix;

        public Matrix(int row, int col)
        {
            this.matrix = new T[row, col];
        }

        private int Rows
        {
            get { return this.matrix.GetLength(0); }
        }

        private int Cols
        {
            get { return this.matrix.GetLength(1); }
        }

        public T this[int row, int col]
        {
            get 
            {
                return this.matrix[row, col]; 
            }

            set
            {
                this.matrix[row, col] = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            if (matrix1.Cols != matrix2.Cols || matrix1.Rows != matrix2.Rows)
            {
                throw new FormatException("The matrixes is with different size.");
            }

            Matrix<T> tempMatrix = new Matrix<T>(matrix1.Cols, matrix1.Rows);

            for (int row = 0; row < matrix1.Rows; row++)
            {
                for (int col = 0; col < matrix1.Cols; col++)
                {
                    tempMatrix[row, col] = (dynamic)matrix1[row, col] + (dynamic)matrix2[row, col];
                }
            }

            return tempMatrix;
        }

        public static Matrix<T> operator -(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            if (matrix1.Cols != matrix2.Cols || matrix1.Rows != matrix2.Rows)
            {
                throw new ArgumentException("Different matrix sizes.");
            }

            Matrix<T> tempMatrix = new Matrix<T>(matrix1.Rows, matrix1.Cols);

            for (int row = 0; row < matrix1.Rows; row++)
            {
                for (int col = 0; col < matrix1.Cols; col++)
                {
                    tempMatrix[row, col] = (dynamic)matrix1[row, col] - (dynamic)matrix2[row, col];
                }
            }

            return tempMatrix;
        }

        public static Matrix<T> operator *(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            if (matrix1.Cols != matrix2.Rows)
            {
                throw new FormatException("Multiplying can be used on matrixes with different rows and cols.");
            }
            else
            {
                Matrix<T> tempMatrix = new Matrix<T>(matrix1.Rows, matrix2.Cols);

                for (int i = 0; i < matrix1.Rows; i++)
                {
                    for (int j = 0; j < matrix2.Cols; j++)
                    {
                        dynamic sum = 0;
                        for (int x = 0; x < matrix2.Cols; x++)
                        {
                            sum = sum + (dynamic)matrix1.matrix[i, x] * (dynamic)matrix2.matrix[x, j];
                        }

                        tempMatrix.matrix[i, j] = sum;
                    }
                }

                return tempMatrix;
            }
        }

        //public static bool operator true(Matrix<T> matrix)
        //{
        //    for (int row = 0; row < matrix.Rows; row++)
        //    {
        //        for (int col = 0; col < matrix.Cols; col++)
        //        {
        //            if (matrix[row, col] == 0)
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    return true;
        //}
    }
}