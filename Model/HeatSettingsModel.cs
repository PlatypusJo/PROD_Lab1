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

        private double _initTime = 0;

        #endregion

        #region Свойства

        public int IDimSize => (int)(IParallepipedSize / H);

        public int JDimSize => (int)(JParallepipedSize / H);

        public int KDimSize => (int)(KParallepipedSize / H);

        // Размеры параллелепипеда в см
        public double IParallepipedSize { get; set; } = 100;

        public double JParallepipedSize { get; set; } = 100;

        public double KParallepipedSize { get; set; } = 100;

        // Границы
        public double Aboundary { get; set; }

        public double AAboundary { get; set; }

        public double Bboundary { get; set; }

        public double BBboundary { get; set; }

        public double Cboundary { get; set; }

        public double CCboundary { get; set; }

        // Шаги и коэффициент 
        public double H { get; set; } = 0.01;

        public double Tau { get; set; } = 0.01;

        public double Alfa { get; set; } = 0.03;

        public double MaxTime { get; set; }

        // Условие устойчивости
        public bool IsStable => (Tau * Alfa * Alfa) / (H * H) < 0.125;

        #endregion

        #region Конструктор

        public HeatSettingsModel()
        {

        }

        #endregion
        

       
    }
}
