using System;
namespace PryamolineynostNew.Models.LevelTool
{
    public class DPoint
    {
        public int X { get; init; }
        public double Y { get; init; }
        public DPoint(int x, decimal y)
        {
            X = x;
            Y = Math.Round(decimal.ToDouble(y), 2);
        }

        public DPoint(int x, double y)
        {
            X = x;
            Y = Math.Round(y, 2);
        }
    }


}
