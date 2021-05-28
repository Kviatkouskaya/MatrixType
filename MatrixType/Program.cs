using System;
using System.Collections.Generic;

namespace MatrixType
{
    public class Matrix
    {
        public int[,] MatrixArray { get; }
        public Matrix(int[,] a)
        {
            MatrixArray = a;
        }
        public static Matrix operator +(Matrix a, Matrix b)
        {
            CheckMatrixDimention(a, b);
            int[,] result = new int[a.MatrixArray.GetLength(0), a.MatrixArray.GetLength(1)];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = a.MatrixArray[i, j] + b.MatrixArray[i, j];
                }
            }
            return new Matrix(result);
        }
        public static Matrix operator -(Matrix a, Matrix b)
        {
            CheckMatrixDimention(a, b);
            int[,] result = new int[a.MatrixArray.GetLength(0), a.MatrixArray.GetLength(1)];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = a.MatrixArray[i, j] - b.MatrixArray[i, j];
                }
            }
            return new Matrix(result);
        }
        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.MatrixArray.GetLength(1) != b.MatrixArray.GetLength(0))
            {
                throw new ArithmeticException("Columns number of matrix A and rows number of matrix B ARE NOT equal!" +
                                              "Operation doesn't available...");
            }
            int[,] result = new int[a.MatrixArray.GetLength(0), b.MatrixArray.GetLength(1)];
            for (int i = 0; i < a.MatrixArray.GetLength(0); i++)
            {
                for (int j = 0; j < b.MatrixArray.GetLength(1); j++)
                {
                    for (var k = 0; k < a.MatrixArray.GetLength(1); k++)
                    {
                        result[i, j] += a.MatrixArray[i, k] * b.MatrixArray[k, j];
                    }
                }
            }
            return new Matrix(result);
        }
        public static Matrix operator *(Matrix a, int number)
        {
            int[,] result = new int[a.MatrixArray.GetLength(0), a.MatrixArray.GetLength(1)];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = a.MatrixArray[i, j] * number;
                }
            }
            return new Matrix(result);
        }
        private static void CheckMatrixDimention(Matrix a, Matrix b)
        {
            if (a.MatrixArray.GetLength(0) != b.MatrixArray.GetLength(0) ||
                a.MatrixArray.GetLength(1) != b.MatrixArray.GetLength(1))
            {
                throw new ArithmeticException("Matrices have different size! " +
                                              "Operation doesn't available...");
            }
        }
    }
    class Program
    {
        public static Matrix InputMatrix()
        {
            Console.WriteLine("Enter matrix:");
            List<string[]> arrayList = new();
            string line = Console.ReadLine();
            while (line != string.Empty)
            {
                foreach (var item in line)
                {
                    if (item != ' ' && !char.IsNumber(item))
                    {
                        throw new ArgumentException($"Error! Invalid symbol: {item} ");
                    }
                }
                arrayList.Add(line.Split(' '));
                line = Console.ReadLine();
            }
            if (arrayList.Count == 0)
            {
                throw new NullReferenceException("Error! Matrix object hasn't any number!");
            }
            int[,] result = new int[arrayList.Count, arrayList[0].Length];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = Convert.ToInt32(arrayList[i][j]);
                }
            }
            return new Matrix(result);
        }
        public static void PrintMatrix(Matrix matrixPrint)
        {
            Console.WriteLine("Matrix is:");
            string line = string.Empty;
            for (int i = 0; i < matrixPrint.MatrixArray.GetLength(0); i++)
            {
                line += "{ ";
                for (int j = 0; j < matrixPrint.MatrixArray.GetLength(1); j++)
                {
                    line += $"{matrixPrint.MatrixArray[i, j]} ";
                }
                line += "}";
                Console.WriteLine(line);
                line = string.Empty;
            }
            Console.WriteLine();
        }
        static void Main()
        {
            try
            {
                Matrix matrixA = InputMatrix();
                Matrix matrixB = InputMatrix();
                PrintMatrix(matrixA);
                PrintMatrix(matrixB);
                Console.WriteLine("\tSummurize operation result");
                PrintMatrix(matrixA + matrixB);
                Console.WriteLine("\tSubstact operation result");
                PrintMatrix(matrixA - matrixB);
                Console.WriteLine("\tMultiply operation result");
                PrintMatrix(matrixA * matrixB);
                Console.WriteLine("Enter number for multiplication:");
                int number = Convert.ToInt32(Console.ReadLine());
                PrintMatrix(matrixA * number);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
