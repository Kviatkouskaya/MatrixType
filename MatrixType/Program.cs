using System;

namespace MatrixType
{
    public class Matrix
    {
        public static int[] SummarizeMatrix(int[] a, int[] b)
        {
            CheckMatrixEqual(a, b);
            int[] result = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                result[i] = a[i] + b[i];
            }
            return result;
        }
        public static int[,] SummarizeMatrix(int[,] a, int[,] b)
        {
            CheckMatrixEqual(a, b);
            int[,] result = new int[a.GetLength(0), a.GetLength(1)];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }
            return result;
        }
        public static int[] MultiplyMatrixToNumber(int[] a, int number)
        {
            int[] result = new int[a.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = a[i] * number;
            }
            return result;
        }
        public static int[,] MultiplyMatrixToNumber(int[,] a, int number)
        {
            int[,] result = new int[a.GetLength(0), a.GetLength(1)];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = a[i, j] * number;
                }
            }
            return result;
        }
        public static int[] SubtractMatrix(int[] a, int[] b)
        {
            CheckMatrixEqual(a, b);
            int[] result = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                result[i] = a[i] - b[i];
            }
            return result;
        }
        public static int[,] SubtractMatrix(int[,] a, int[,] b)
        {
            CheckMatrixEqual(a, b);
            int[,] result = new int[a.GetLength(0), a.GetLength(1)];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = a[i, j] - b[i, j];
                }
            }
            return result;
        }
        public static int[,] MultiplyMatrix(int[,] a, int[,] b)
        {
            if (a.GetLength(1) != b.GetLength(0))
            {
                throw new ArithmeticException("Columns number of matrix A and rows number of matrix B ARE NOT equal!" +
                                              "Operation doesn't available...");
            }
            int[,] result = new int[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (var k = 0; k < a.GetLength(1); k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return result;
        }
        public static void CheckMatrixEqual(int[] a, int[] b)
        {
            if (a.Length != b.Length)
            {
                throw new ArithmeticException("Matrices have different length! " +
                                              "Operation doesn't available...");
            }
        }
        public static void CheckMatrixEqual(int[,] a, int[,] b)
        {
            if (a.GetLength(0) != b.GetLength(0) || a.GetLength(1) != b.GetLength(1))
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
