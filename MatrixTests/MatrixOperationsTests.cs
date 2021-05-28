using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixType;

namespace MatrixTests
{
    [TestClass]
    public class MatrixOperationsTests
    {
        [DataRow(2, 2, 2, 2, 3, 3, 3, 3, 5, 5, 5, 5)]
        [DataRow(1, 1, 1, 1, 3, 3, 3, 3, 4, 4, 4, 4)]
        [DataRow(3, 4, 5, 3, 1, 1, 1, 1, 4, 5, 6, 4)]
        [DataTestMethod]
        public void SummurizeMatrixTest2(int a, int a1, int a2, int a3, int b, int b1,
                                        int b2, int b3, int c, int c1, int c2, int c3)
        {
            int[,] arrayA = { { a, a1, }, { a2, a3 } };
            int[,] arrayB = { { b, b1 }, { b2, b3 } };
            int[,] arrayC = { { c, c1 }, { c2, c3 } };
            Matrix actual = new Matrix(arrayA) + new Matrix(arrayB);
            Matrix expected = new(arrayC);
            bool result = true;
            for (int i = 0; i < expected.MatrixArray.GetLength(0); i++)
            {
                for (int j = 0; j < expected.MatrixArray.GetLength(1); j++)
                {
                    if (actual.MatrixArray[i, j] != expected.MatrixArray[i, j])
                    {
                        result = false;
                    }
                }
            }
            Assert.IsTrue(result);
        }

        [DataRow(2, 2, 2, 3, 3, 3, 5, 5, 5)]
        [DataRow(1, 1, 1, 1, 1, 1, 2, 2, 2)]
        [DataRow(2, 3, 4, 2, 3, 4, 4, 6, 8)]
        [DataTestMethod]
        public void SummarizeMatrixTest(int a, int a1, int a2, int b, int b1, int b2, int c, int c1, int c2)
        {
            int[,] arrayA = { { a }, { a1 }, { a2 } };
            int[,] arrayB = { { b }, { b1 }, { b2 } };
            int[,] arrayC = { { c }, { c1 }, { c2 } };
            Matrix actual = new Matrix(arrayA) + new Matrix(arrayB);
            Matrix expected = new(arrayC);
            bool result = true;
            for (int i = 0; i < expected.MatrixArray.GetLength(0); i++)
            {
                for (int j = 0; j < expected.MatrixArray.GetLength(1); j++)
                {
                    if (actual.MatrixArray[i, j] != expected.MatrixArray[i, j])
                    {
                        result = false;
                    }
                }
            }
            Assert.IsTrue(result);
        }

        [DataRow(2, 3, 4, 2, 5, 10, 15, 20, 10)]
        [DataRow(4, 4, 4, 4, 2, 8, 8, 8, 8)]
        [DataRow(6, 6, 3, 3, 2, 12, 12, 6, 6)]
        [DataTestMethod]
        public void MultiplyMatrixToNumberTest(int a, int a1, int a2, int a3, int number,
                                                       int b, int b1, int b2, int b3)
        {
            int[,] arrayA = { { a, a1 }, { a2, a3 } };
            int[,] arrayB = { { b, b1 }, { b2, b3 } };
            Matrix actual = new Matrix(arrayA) * number;
            Matrix expected = new(arrayB);
            bool result = true;
            for (int i = 0; i < actual.MatrixArray.GetLength(0); i++)
            {
                for (int j = 0; j < actual.MatrixArray.GetLength(1); j++)
                {
                    if (actual.MatrixArray[i, j] != expected.MatrixArray[i, j])
                    {
                        result = false;
                    }
                }
            }
            Assert.IsTrue(result);
        }

        [DataRow(5, 5, 5, 2, 3, 1, 3, 2, 4)]
        [DataRow(2, 1, 3, 2, 2, 2, 0, -1, 1)]
        [DataRow(1, 1, 1, 3, 3, 3, -2, -2, -2)]
        [DataTestMethod]
        public void SubtractMatrixTest(int a, int a1, int a2, int b, int b1, int b2, int c, int c1, int c2)
        {
            int[,] arrayA = { { a }, { a1 }, { a2 } };
            int[,] arrayB = { { b }, { b1 }, { b2 } };
            int[,] arrayC = { { c }, { c1 }, { c2 } };
            Matrix actual = new Matrix(arrayA) - new Matrix(arrayB);
            Matrix expected = new(arrayC);
            bool result = true;
            for (int i = 0; i < expected.MatrixArray.GetLength(0); i++)
            {
                for (int j = 0; j < expected.MatrixArray.GetLength(1); j++)
                {
                    if (actual.MatrixArray[i, j] != expected.MatrixArray[i, j])
                    {
                        result = false;
                    }
                }
            }
            Assert.IsTrue(result);
        }

        [DataRow(-1, 3, 0, 1, 2, -2, 0, 2, 0, -1, 1, -3, 4, 0, 3, -11, 12, 1, 1, -3, 4, 0, -2, 10, -8, -2)]
        [DataRow(1, 2, 3, 4, 5, 6, 1, 2, 3, 4, 5, 6, 7, 8, 11, 14, 17, 20, 23, 30, 37, 44, 35, 46, 57, 68)]
        [DataRow(0, -1, -2, -3, 0, -1, 2, 1, 2, 1, 1, 2, 1, 2, -1, -2, -1, -2, -7, -8, -7, -8, -1, -2, -1, -2)]
        [DataTestMethod]
        public void MultiplyMatrixTest(int a, int a1, int a2, int a3, int a4, int a5,
                                                       int b, int b1, int b2, int b3, int b4, int b5, int b6, int b7,
                                                       int c, int c1, int c2, int c3, int c4, int c5, int c6, int c7,
                                                       int c8, int c9, int c10, int c11)
        {
            int[,] arrayA = { { a, a1 }, { a2, a3 }, { a4, a5 } };
            int[,] arrayB = { { b, b1, b2, b3 }, { b4, b5, b6, b7 } };
            int[,] arrayC = { { c, c1, c2, c3 }, { c4, c5, c6, c7 }, { c8, c9, c10, c11 } };
            Matrix actual = new Matrix(arrayA) * new Matrix(arrayB);
            Matrix expected = new(arrayC);
            bool result = true;
            for (int i = 0; i < expected.MatrixArray.GetLength(0); i++)
            {
                for (int j = 0; j < expected.MatrixArray.GetLength(1); j++)
                {
                    if (actual.MatrixArray[i, j] != expected.MatrixArray[i, j])
                    {
                        result = false;
                    }
                }
            }
            Assert.IsTrue(result);
        }
    }
}