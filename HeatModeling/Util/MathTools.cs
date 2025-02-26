using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Util
{
    public static class MathTools
    {
        public static double[][] GetDataCutXY(this double[][][] origData)
        {
            int xSize = origData.Length;
            int ySize = origData[0].Length;
            int k = origData[0][0].Length / 2;

            double[][] dataCut = new double[xSize][];
            for (int i = 0; i < xSize; i++)
                dataCut[i] = new double[ySize];

            for (int i = 0; i < xSize; i++)
                for (int j = 0; j < ySize; j++)
                    dataCut[i][j] = origData[i][j][k];

            return dataCut;
        }

        public static double[][] GetDataCutXZ(this double[][][] origData)
        {
            int xSize = origData.Length;
            int zSize = origData[0][0].Length;
            int j = origData[0].Length / 2;

            double[][] dataCut = new double[xSize][];
            for (int k = 0; k < xSize; k++)
                dataCut[k] = new double[zSize];

            for (int i = 0; i < xSize; i++)
                for (int k = 0; k < zSize; k++)
                    dataCut[i][k] = origData[i][j][k];

            return dataCut;
        }

        public static double[][] GetDataCutYZ(this double[][][] origData)
        {
            int ySize = origData[0].Length;
            int zSize = origData[0][0].Length;
            int i = origData.Length / 2;

            double[][] dataCut = new double[ySize][];
            for (int j = 0; j < ySize; j++)
                dataCut[j] = new double[zSize];

            for (int j = 0; j < ySize; j++)
                for (int k = 0; k < zSize; k++)
                    dataCut[j][k] = origData[i][j][k];

            return dataCut;
        }
    }
}
