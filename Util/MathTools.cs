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
        public static double[,] GetDataCutXY(this double[,,] origData)
        {
            int xSize = origData.GetUpperBound(0) + 1;
            int ySize = origData.GetUpperBound(1) + 1;
            int k = (origData.GetUpperBound(2) + 1) / 2;

            double[,] dataCut = new double[xSize, ySize];
            for (int i = 0; i < xSize; i++)
                for (int j = 0; j < ySize; j++)
                    dataCut[i, j] = origData[i, j, k];

            return dataCut;
        }

        public static double[,] GetDataCutXZ(this double[,,] origData)
        {
            int xSize = origData.GetUpperBound(0) + 1;
            int zSize = origData.GetUpperBound(2) + 1;
            int j = (origData.GetUpperBound(1) + 1) / 2;

            double[,] dataCut = new double[xSize, zSize];
            for (int i = 0; i < xSize; i++)
                for (int k = 0; k < zSize; k++)
                    dataCut[i, k] = origData[i, j, k];

            return dataCut;
        }

        public static double[,] GetDataCutYZ(this double[,,] origData)
        {
            int ySize = origData.GetUpperBound(1) + 1;
            int zSize = origData.GetUpperBound(2) + 1;
            int i = (origData.GetUpperBound(0) + 1) / 2;

            double[,] dataCut = new double[ySize, zSize];
            for (int j = 0; j < ySize; j++)
                for (int k = 0; k < zSize; k++)
                    dataCut[j, k] = origData[i, j, k];

            return dataCut;
        }
    }
}
