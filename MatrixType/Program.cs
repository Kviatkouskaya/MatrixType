using System;

namespace MatrixType
{
    public class Matrix
    {
        public static int[] SummMatrix(int[] a, int[] b)
        {
            int[] result = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                result[i] = a[i] + b[i];
            }
            return result;
        }
        public static int[,] SummMatrix(int[,] a, int[,] b)
        {
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
            int[,] result = new int[a.GetLength(0),a.GetLength(1)];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = a[i, j] * number;
                }
            }
            return result;
        }
    }
    class Program
    {
        static void Main()
        {

        }
    }
}
