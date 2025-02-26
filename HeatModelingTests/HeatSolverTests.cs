using Lab1.Model;
using Lab1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1UnitTests
{
    public class HeatSolverTests
    {
        [Fact]
        public void CalculateTemperature_PassCorrectParameters_GetCubeWithZeroPointInMiddle_Test()
        {
            // Arrange:
            HeatSettingsModel settings = new();
            HeatSolver solver = new(settings);

            // Act:
            double[][][] arr = solver.CalculateTemperature(out double _);
            double middlePoint = arr[settings.IDimSize / 2][settings.JDimSize / 2][settings.KDimSize / 2];
            bool actual = middlePoint >= 0 && middlePoint <= 0.1;

            // Assert:
            Assert.True(actual);
        }
        
    }
}
