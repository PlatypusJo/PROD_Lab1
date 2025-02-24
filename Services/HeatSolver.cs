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

        private double[,,] _u;

        private double[,,] _uNew;

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

            InitializeTemperature();
        }

        #endregion

        #region Методы

        public double[,,,] Step()
        {
            return null;
        }

        public double[,,,] StepParallel()
        {
            return null;
        }

        public double CalculateTemperature()
        {
            return 0;
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

            InitializeTemperature();
        }

        #endregion

        #region Внутренние методы

        private void InitializeTemperature()
        {
            _u = new double[_iDim, _jDim, _kDim];

            for (int i = 0; i < _iDim; i++)
                for (int j = 0; j < _jDim; j++)
                    for (int k = 0; k < _kDim; k++)
                        _u[i, j, k] = 0;

            _uNew = _u;
        }

        #endregion

    }
}
