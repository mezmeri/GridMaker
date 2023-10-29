using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatShare_Demo
{
    public class Route
    {
        public double CalculateDistanceBetweenPoints(Point x1, Point x2, Point y1, Point y2)
        {
            double distance = Math.Sqrt(Math.Pow(x2.X - x1.X, 2) + Math.Pow(y1.Y - y2.Y, 2));
            return distance;
        }
    }
}
