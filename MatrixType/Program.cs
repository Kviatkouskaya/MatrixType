using System;

namespace MatrixType
{
    public class Matrix
    {
        public int[] oneDimension;
        public int[,] twoDimension;
        public int matrixDimensions;
        public Matrix(int[] a)
        {
            oneDimension = a;
            matrixDimensions = a.Rank;
        }
        public Matrix(int[,] a)
        {
            twoDimension = a;
            matrixDimensions = a.Rank;
        }
        public static Matrix operator +(Matrix a, Matrix b)
        {
            CheckMatrixEqual(a, b);
            if (a.matrixDimensions == 1)
            {
                int[] result = new int[a.oneDimension.Length];
                for (int i = 0; i < a.oneDimension.Length; i++)
                {
                    result[i] = a.oneDimension[i] + b.oneDimension[i];
                }
                return new Matrix(result);
            }
            else
            {
                int[,] result = new int[a.twoDimension.GetLength(0), a.twoDimension.GetLength(1)];
                for (int i = 0; i < result.GetLength(0); i++)
                {
                    for (int j = 0; j < result.GetLength(1); j++)
                    {
                        result[i, j] = a.twoDimension[i, j] + b.twoDimension[i, j];
                    }
                }
                return new Matrix(result);
            }
        }
        public static Matrix operator -(Matrix a, Matrix b)
        {
            CheckMatrixEqual(a, b);
            if (a.matrixDimensions == 1)
            {
                int[] result = new int[a.oneDimension.Length];
                for (int i = 0; i < a.oneDimension.Length; i++)
                {
                    result[i] = a.oneDimension[i] - b.oneDimension[i];
                }
                return new Matrix(result);
            }
            else
            {
                int[,] result = new int[a.twoDimension.GetLength(0), a.twoDimension.GetLength(1)];
                for (int i = 0; i < result.GetLength(0); i++)
                {
                    for (int j = 0; j < result.GetLength(1); j++)
                    {
                        result[i, j] = a.twoDimension[i, j] - b.twoDimension[i, j];
                    }
                }
                return new Matrix(result);
            }
        }
        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.oneDimension != null && a.oneDimension.Length == 1 && b.matrixDimensions == 1)
            {
                return b * a.oneDimension[0];
            }
            else
            {
                if (a.twoDimension.GetLength(1) != b.twoDimension.GetLength(0))
                {
                    throw new ArithmeticException("Columns number of matrix A and rows number of matrix B ARE NOT equal!" +
                                                  "Operation doesn't available...");
                }
                int[,] result = new int[a.twoDimension.GetLength(0), b.twoDimension.GetLength(1)];
                for (int i = 0; i < a.twoDimension.GetLength(0); i++)
                {
                    for (int j = 0; j < b.twoDimension.GetLength(1); j++)
                    {
                        for (var k = 0; k < a.twoDimension.GetLength(1); k++)
                        {
                            result[i, j] += a.twoDimension[i, k] * b.twoDimension[k, j];
                        }
                    }
                }
                return new Matrix(result);
            }
        }
        public static Matrix operator *(Matrix a, int number)
        {
            if (a.matrixDimensions == 1)
            {
                int[] result = new int[a.oneDimension.Length];
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = a.oneDimension[i] * number;
                }
                return new Matrix(result);
            }
            else
            {
                int[,] result = new int[a.twoDimension.GetLength(0), a.twoDimension.GetLength(1)];
                for (int i = 0; i < result.GetLength(0); i++)
                {
                    for (int j = 0; j < result.GetLength(1); j++)
                    {
                        result[i, j] = a.twoDimension[i, j] * number;
                    }
                }
                return new Matrix(result);
            }
        }
        public static void CheckMatrixEqual(Matrix a, Matrix b)
        {
            if (a.matrixDimensions == 1 && a.oneDimension.Length != b.oneDimension.Length)
            {
                throw new ArithmeticException("Matrices have different length! " +
                                              "Operation doesn't available...");
            }
            if (a.matrixDimensions == 2 && (a.twoDimension.GetLength(0) != b.twoDimension.GetLength(0) ||
                                             a.twoDimension.GetLength(1) != b.twoDimension.GetLength(1)))
            {
                throw new ArithmeticException("Matrices have different size! " +
                                              "Operation doesn't available...");
            }
        }
    }
    class Program
    {
        public static int[] InputMatrix()
        {
            Console.WriteLine("Enter matrix:");
            string[] line = Console.ReadLine().Split(' ');
            int[] matrix = Array.ConvertAll(line, Convert.ToInt32);
            return matrix;
        }
        /* public static int[,] InputMatrix()
         {

         }*/
        public static void PrintMatrix(int[] matrix)
        {
            Console.WriteLine($"\nMatrix is:");
            Console.Write("{ ");
            foreach (var item in matrix)
            {
                Console.Write(item + " ");
            }
            Console.Write("}\n");
        }
        public static void PrintMatrix(int[,] matrix, string name)
        {
            Console.WriteLine($"Matrix {name} is:\n");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write("{ ");
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.Write("}\n");
            }
        }

        static void Main()
        {
            int[] matrixA = InputMatrix();
            PrintMatrix(matrixA);
        }
    }
}
