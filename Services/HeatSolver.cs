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
            return null;
        }

        public double[][][] CalculateTemperatureParallel()
        {
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
        }

        #endregion

    }
}
