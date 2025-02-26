using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Model
{
    public class HeatSettingsModel
    {
        #region Свойства

        public int IDimSize => (int)(IParallepipedSize / H);

        public int JDimSize => (int)(JParallepipedSize / H);

        public int KDimSize => (int)(KParallepipedSize / H);

        // Размеры параллелепипеда в см
        public double IParallepipedSize { get; set; } = 0.1;

        public double JParallepipedSize { get; set; } = 0.1;

        public double KParallepipedSize { get; set; } = 0.1;

        // Границы
        public double Aboundary { get; set; } = 4;

        public double AAboundary { get; set; } = 4;

        public double Bboundary { get; set; } = 4;

        public double BBboundary { get; set; } = 4;

        public double Cboundary { get; set; } = 4;

        public double CCboundary { get; set; } = 4;

        // Шаги и коэффициент 
        public double H { get; set; } = 0.01;

        public double Tau { get; set; } = 0.01;

        public double Alfa { get; set; } = 0.03;

        public double MaxTime { get; set; } = 10;

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
