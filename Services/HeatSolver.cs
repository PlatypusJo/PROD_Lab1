using Lab1.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private double _initTime = 0;

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

        public double[][][] CalculateTemperature(out double executionTime)
        {
            InitializeTemperature();

            double coeff = (_settings.Tau * _settings.Alfa * _settings.Alfa) / _settings.H * _settings.H;

            Stopwatch timer = new();
            timer.Start();

            for (double t = _initTime; t < _settings.MaxTime; t += _settings.Tau)
            {
                for (int i = 1; i < _iDim - 1; i++)
                    for (int j = 1; j < _jDim - 1; j++)
                        for (int k = 1; k < _kDim - 1; k++)
                            _uNew[i][j][k] = _u[i][j][k] + coeff *
                                (_u[i + 1][j][k] + _u[i - 1][j][k] + _u[i][j + 1][k] +
                                _u[i][j - 1][k] + _u[i][j][k + 1] + _u[i][j][k - 1] - 6 * _u[i][j][k]);

                CopyArray(_uNew, _u);
            }

            timer.Stop();
            executionTime = timer.Elapsed.TotalMilliseconds / 1000;

            return _u;
        }

        public double[][][] CalculateTemperatureParallel(out double executionTime)
        {
            InitializeTemperature();
            double coeff = (_settings.Tau * _settings.Alfa * _settings.Alfa) / _settings.H * _settings.H;

            Stopwatch timer = new();
            timer.Start();


            for (double t = _initTime; t < _settings.MaxTime; t += _settings.Tau)
            {
                Parallel.For(1, _iDim - 1, i =>
                {
                    for (int j = 1; j < _jDim - 1; j++)
                        for (int k = 1; k < _kDim - 1; k++)
                            _uNew[i][j][k] = _u[i][j][k] + coeff *
                                (_u[i + 1][j][k] + _u[i - 1][j][k] + _u[i][j + 1][k] +
                                _u[i][j - 1][k] + _u[i][j][k + 1] + _u[i][j][k - 1] - 6 * _u[i][j][k]);
                });

                CopyArray(_uNew, _u);
            }
            
            timer.Stop();
            executionTime = timer.Elapsed.TotalMilliseconds / 1000;

            return _u;
        }

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

        private void CopyArray(double[][][] src, double[][][] dst)
        {
            for (int i = 0; i < _iDim; i++)
                for (int j = 0; j < _jDim; j++)
                    for (int k = 0; k < _kDim; k++)
                        dst[i][j][k] = src[i][j][k];
        }

        private void InitializeTemperature()
        {
            _u = new double[_iDim][][];
            _uNew = new double[_iDim][][];

            Parallel.For(0, _iDim, i =>
            {
                _u[i] = new double[_jDim][];
                _uNew[i] = new double[_jDim][];
                for (int j = 0; j < _jDim; j++)
                {
                    _u[i][j] = new double[_kDim];
                    _uNew[i][j] = new double[_kDim];
                    for (int k = 0; k < _kDim; k++)
                    {
                        _u[i][j][k] = 0;
                        _uNew[i][j][k] = 0;
                    }
                }
            });

            int iMax = _iDim - 1;
            int jMax = _jDim - 1;
            int kMax = _kDim - 1;

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

            CopyArray(_u, _uNew);
        }

        #endregion
        
    }
}
