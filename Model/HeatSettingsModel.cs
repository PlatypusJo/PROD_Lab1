using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Model
{
    public class HeatSettingsModel
    {

        #region Поля

        private double _aBoundary = 0;
        private double _aaBoundary = 0;

        private double _bBoundary = 0;
        private double _bbBoundary = 0;

        private double _cBoundary = 0;
        private double _ccBoundary = 0;

        // Размеры параллелепипеда в см
        private double _iParallelepipedSize = 100;
        private double _jParallelepipedSize = 100;
        private double _kParallelepipedSize = 100;

        // Шаги и коэффициент
        private double h = 0.01;
        private double tau = 0.01;
        private double a = 0.03;

        private double _initTime = 0;
        private double _maxTime;

        // Условие устойчивости
        private bool _isStable => (tau * a * a) / (h * h) < 0.125;

        #endregion

        #region Свойства

        public int IDimSize => (int)(_iParallelepipedSize / h);
        public int JDimSize => (int)(_jParallelepipedSize / h);
        public int KDimSize => (int)(_kParallelepipedSize / h);

        #endregion

        #region Конструктор

        public HeatSettingsModel()
        {
            
        }

        #endregion
        

       
    }
}
