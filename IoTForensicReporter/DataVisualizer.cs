using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;

namespace IoTForensicSolution.IoTForensicReporter
{
    public static class DataVisualizer
    {
        public static void PlotData(List<float> dataPoints)
        {
            var plotModel = new PlotModel { Title = "Sensor Data Over Time" };

            var lineSeries = new LineSeries();
            for (int i = 0; i < dataPoints.Count; i++)
            {
                lineSeries.Points.Add(new DataPoint(i, dataPoints[i]));
            }

            plotModel.Series.Add(lineSeries);

            using (var stream = new System.IO.MemoryStream())
            {
                var pngExporter = new OxyPlot.WindowsForms.PngExporter { Width = 600, Height = 400 };
                pngExporter.Export(plotModel, stream);
                stream.Seek(0, System.IO.SeekOrigin.Begin);

                using (var fileStream = new System.IO.FileStream("SensorDataPlot.png", System.IO.FileMode.Create))
                {
                    stream.CopyTo(fileStream);
                }
            }

            Console.WriteLine("Plot saved as SensorDataPlot.png");
        }
    }
}
