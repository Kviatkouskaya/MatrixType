using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatrixTests
{
    [TestClass]
    public class MatrixOperationTests
    {
        [DataRow(2, 2, 3, 4, 5, 6)]
        [DataRow(4, 3, 5, 6, 9, 9)]
        [DataRow(6, 5, 3, 4, 9, 9)]
        [DataTestMethod]
        public void SummTestOneRow(int a, int a1, int b, int b1, int c, int c1)
        {
            int[] arrayA = { a, a1 };
            int[] arrayB = { b, b1 };
            int[] actual = MatrixType.Matrix.SummMatrix(arrayA, arrayB);
            int[] expected = { c, c1 };
            bool result = true;
            for (int i = 0; i < expected.Length; i++)
            {
                if (actual[i] != expected[i])
                {
                    result = false;
                }
            }
            Assert.IsTrue(result);
        }

        [DataRow(2, 2, 2, 2, 3, 3, 3, 3, 5, 5, 5, 5)]
        [DataRow(1, 1, 1, 1, 3, 3, 3, 3, 4, 4, 4, 4)]
        [DataRow(3, 4, 5, 3, 1, 1, 1, 1, 4, 5, 6, 4)]
        [DataTestMethod]
        public void SummTestTwoRowArray(int a, int a1, int a2, int a3, int b, int b1, int b2, int b3, int c, int c1, int c2, int c3)
        {
            int[,] arrayA = { { a, a1, }, { a2, a3 } };
            int[,] arrayB = { { b, b1 }, { b2, b3 } };
            int[,] actual = MatrixType.Matrix.SummMatrix(arrayA, arrayB);
            int[,] expected = { { c, c1 }, { c2, c3 } };
            bool result = true;
            for (int i = 0; i < expected.GetLength(0); i++)
            {
                for (int j = 0; j < expected.GetLength(1); j++)
                {
                    if (actual[i, j] != expected[i, j])
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
        public void SummTestThreeRowArray(int a, int a1, int a2, int b, int b1, int b2, int c, int c1, int c2)
        {
            int[,] arrayA = { { a }, { a1 }, { a2 } };
            int[,] arrayB = { { b }, { b1 }, { b2 } };
            int[,] actual = MatrixType.Matrix.SummMatrix(arrayA, arrayB);
            int[,] expected = { { c }, { c1 }, { c2 } };
            bool result = true;
            for (int i = 0; i < expected.GetLength(0); i++)
            {
                for (int j = 0; j < expected.GetLength(1); j++)
                {
                    if (actual[i, j] != expected[i, j])
                    {
                        result = false;
                    }
                }
            }
            Assert.IsTrue(result);
        }

        [DataRow(1, 1, 1, 6, 6, 6, 6)]
        [DataRow(2, 3, 4, 5, 10, 15, 20)]
        [DataTestMethod]
        public void MultiplyNumberTest(int a, int a1, int a2, int number, int b, int b1, int b2)
        {
            int[] arrayA = { a, a1, a2 };
            int[] actual = MatrixType.Matrix.MultiplyMatrixToNumber(arrayA, number);
            int[] expected = { b, b1, b2 };
            bool result = true;
            for (int i = 0; i < actual.Length; i++)
            {
                if (actual[i] != expected[i])
                {
                    result = false;
                }
            }
            Assert.IsTrue(result);
        }

        [DataRow(2, 3, 4, 2, 5, 10, 15, 20, 10)]
        [DataTestMethod]
        public void MultiplyNumberMultidimensionalTest(int a, int a1, int a2, int a3, int number, int b, int b1, int b2, int b3)
        {
            int[,] arrayA = { { a, a1 }, { a2, a3 } };
            int[,] actual = MatrixType.Matrix.MultiplyMatrixToNumber(arrayA, number);
            int[,] expected = { { b, b1 }, { b2, b3 } };
            bool result = true;
            for (int i = 0; i < actual.GetLength(0); i++)
            {
                for (int j = 0; j < actual.GetLength(1); j++)
                {
                    if (actual[i, j] != expected[i, j])
                    {
                        result = false;
                    }
                }
            }
            Assert.IsTrue(result);
        }
    }
}