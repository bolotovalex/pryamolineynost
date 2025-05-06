using System.Linq;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Legends;        // ← обязательно
using OxyPlot.Series;
using PryamolineynostWF.Models.Collimator;
using PryamolineynostWF.Views.Collimator;
using PryamolineynostWF.Enums;

namespace PryamolineynostWF.Controllers.Collimator
{
    public class MeasurementChartController
    {
        private readonly MeasurementTableModel _tableModel;
        private readonly ChartForm _view;

        public MeasurementChartController(MeasurementTableModel tableModel)
        {
            _tableModel = tableModel;
            _view = new ChartForm();
            RenderChart();
        }

        private void RenderChart()
        {
            // 1. Берём все, кроме последней точки, X = Position
            var data = _tableModel.Table
                        .Take(_tableModel.Table.Count - 1)
                        .ToList();
            var xValues = data.Select(r => (double)r.Position).ToList();  // :contentReference[oaicite:1]{index=1}

            // 2. Собираем 4 Y-серии
            var yOrdHor = data.Select(r => (double)(r.OrdinateStraightnessHorizontal ?? 0m)).ToList(); // :contentReference[oaicite:3]{index=3}
            var yDevHor = data.Select(r => (double)(r.RelativeAngleToFirstHorizontal ?? 0m)).ToList(); // :contentReference[oaicite:5]{index=5}
            var yOrdVer = data.Select(r => (double)(r.OrdinateStraightnessVertical ?? 0m)).ToList();   // :contentReference[oaicite:7]{index=7}
            var yDevVer = data.Select(r => (double)(r.RelativeAngleToFirstVertical ?? 0m)).ToList();   // :contentReference[oaicite:9]{index=9}

            // 3. Настраиваем PlotModel и оси
            var plotModel = new PlotModel { Title = "Отклонение от прямолинейности" };
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Position" });
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Значение, мкм" });

            // 4. Добавляем Legend (новый API в 2.x)
            var legend = new Legend
            {
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.TopRight,
                LegendOrientation = LegendOrientation.Vertical,
                LegendTitle = "Серии"
            };
            plotModel.Legends.Add(legend);  // :contentReference[oaicite:10]{index=10}

            // 5. В зависимости от плоскости рисуем нужные линии
            var plane = _tableModel.Plane;

            void AddSeries(string title, MarkerType marker, IList<double> ys)
            {
                var s = new LineSeries { Title = title, MarkerType = marker, StrokeThickness = 2 };
                for (int i = 0; i < xValues.Count; i++)
                    s.Points.Add(new DataPoint(xValues[i], ys[i]));
                plotModel.Series.Add(s);
            }

            if (plane == Plane.Horizontal || plane == Plane.Both)
            {
                AddSeries("Bi (гориз.)", MarkerType.Circle, yOrdHor);
                AddSeries("Hi (гориз.)", MarkerType.Diamond, yDevHor);
            }
            if (plane == Plane.Vertical || plane == Plane.Both)
            {
                AddSeries("Bi (верт.)", MarkerType.Triangle, yOrdVer);
                AddSeries("Hi (верт.)", MarkerType.Square, yDevVer);
            }

            // 6. Отображаем
            _view.PlotView.Model = plotModel;
        }

        public void ShowForm() => _view.Show();
    }
}
