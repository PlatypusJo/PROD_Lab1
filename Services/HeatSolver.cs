using Lab1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Services
{
    public class HeatSolver
    {
        #region Поля

        private double[][][] _u;

        private double[][][] _uNew;

        private int _iDim;

        private int _jDim;

        private int _kDim;

        private HeatSettingsModel _settings;

        #endregion

        #region Конструкторы

        public HeatSolver(HeatSettingsModel settings)
        {
            _settings = settings;

            _iDim = _settings.IDimSize;
            _jDim = _settings.JDimSize;
            _kDim = _settings.KDimSize;
        }

        #endregion

        #region Методы

        public double[][][] CalculateTemperature()
        {
            InitializeTemperature();
            return null;
        }

        public double[][][] CalculateTemperatureParallel()
        {
            InitializeTemperature();
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        public void UpdateHeatSettings(HeatSettingsModel settings)
        {
            if (settings is null)
                return;

            _settings = settings;

            _iDim = _settings.IDimSize;
            _jDim = _settings.JDimSize;
            _kDim = _settings.KDimSize;
        }

        #endregion

        #region Внутренние методы

        private void InitializeTemperature()
        {
            double[][][] uTemp = new double[_iDim][][];

            Parallel.For(0, _iDim, i =>
            {
                uTemp[i] = new double[_jDim][];
                for (int j = 0; j < _jDim; j++)
                {
                    uTemp[i][j] = new double[_kDim];
                    for (int k = 0; k < _kDim; k++)
                    {
                        uTemp[i][j][k] = 0;
                    }
                }
            });

            _uNew = _u = uTemp;

            int iMax = _u.Length - 1;
            int jMax = _u[0].Length - 1;
            int kMax = _u[0][0].Length - 1;

            Parallel.For(0, _iDim, i =>
            {
                for (int j = 0; j < _jDim; j++)
                {
                    _u[i][j][0] = _settings.Aboundary;
                    _u[i][j][kMax] = _settings.AAboundary;
                }
            });

            Parallel.For(0, _iDim, i =>
            {
                for (int k = 0; k < _kDim; k++)
                {
                    _u[i][0][k] = _settings.CCboundary;
                    _u[i][jMax][k] = _settings.Cboundary;
                }
            });

            Parallel.For(0, _jDim, j =>
            {
                for (int k = 0; k < _kDim; k++)
                {
                    _u[0][j][k] = _settings.Bboundary;
                    _u[iMax][j][k] = _settings.BBboundary;
                }
            });

            _uNew = _u;
        }

        #endregion

    }
}
