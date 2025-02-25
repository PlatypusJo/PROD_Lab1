﻿﻿using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Model
{
    public class PlaneModel
    {
        #region Поля

        // <summary>
        /// Модель графика
        /// </summary>
        private PlotModel _plotModel;

        /// <summary>
        /// Данные отображаемые на графике
        /// </summary>
        private HeatMapSeries _heatMapData;

        #endregion

        #region Свойства

        public PlotModel Plot => _plotModel;

        #endregion

        #region Конструктор

        public PlaneModel(int numberOfColors, string plotTitle)
        {
            _plotModel = new PlotModel { Title = plotTitle };
            _plotModel.Axes.Add(new LinearColorAxis { Position = AxisPosition.Right, Palette = OxyPalettes.Jet(numberOfColors) });
            _heatMapData = new HeatMapSeries();
        }

        #endregion

        #region Методы

        public void UpdatePlotModel(double[,] data, int xSize, int ySize)
        {
            _plotModel.Series.Clear();
            var heatMap = new OxyPlot.Series.HeatMapSeries
            {
                X0 = 0,
                X1 = xSize / 2,
                Y0 = 0,
                Y1 = ySize / 2,
                Interpolate = true,
                RenderMethod = HeatMapRenderMethod.Bitmap,
                Data = data
            };
            _plotModel.Series.Add(heatMap);
            _plotModel.InvalidatePlot(true);
        }

        #endregion
    }
}
