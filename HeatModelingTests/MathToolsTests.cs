using Lab1.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1UnitTests
{
    public class MathToolsTests
    {
        #region Тесты

        [Fact]
        public void GetDataCutXY_PassCorrectParameters_GetExpectedResult_Test()
        {
            // Arrange:
            int size = 5;
            double[][][] cube = InitCube(size);

            double[][] expected = new double[size][];
            for (int i = 0; i < size; i++)
                expected[i] = new double[size];

            int k = size / 2;
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    expected[i][j] = cube[i][j][k];

            // Act:
            double[][] actual = cube.GetDataCutXY();

            // Assert:
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetDataCutXZ_PassCorrectParameters_GetExpectedResult_Test()
        {
            // Arrange:
            int size = 5;
            double[][][] cube = InitCube(size);

            double[][] expected = new double[size][];
            for (int i = 0; i < size; i++)
                expected[i] = new double[size];

            int j = size / 2;
            for (int i = 0; i < size; i++)
                for (int k = 0; k < size; k++)
                    expected[i][k] = cube[i][j][k];

            // Act:
            double[][] actual = cube.GetDataCutXZ();

            // Assert:
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetDataCutYZ_PassCorrectParameters_GetExpectedResult_Test()
        {
            // Arrange:
            int size = 5;
            double[][][] cube = InitCube(size);

            double[][] expected = new double[size][];
            for (int k = 0; k < size; k++)
                expected[k] = new double[size];

            int i = size / 2;
            for (int j = 0; j < size; j++)
                for (int k = 0; k < size; k++)
                    expected[j][k] = cube[i][j][k];

            // Act:
            double[][] actual = cube.GetDataCutYZ();

            // Assert:
            Assert.Equal(expected, actual);
        }

        #endregion

        #region Внутренние методы

        private double[][][] InitCube(int size)
        {
            double[][][] cube = new double[size][][];
            for (int i = 0; i < size; i++)
            {
                cube[i] = new double[size][];
                for (int j = 0; j < size; j++)
                {
                    cube[i][j] = new double[size];
                    for (int k = 0; k < size; k++)
                    {
                        cube[i][j][k] = i + j + k;
                    }
                }
            }
            return cube;
        }

        #endregion
    }
}
