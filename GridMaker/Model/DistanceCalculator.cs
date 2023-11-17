using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridMaker.Model
{
    public class DistanceCalculator
    {
        public static double CalculateDistanceBetweenPoints(double x1, double x2, double y1, double y2)
        {
            double distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y1 - y2, 2));
            return distance;
        }
    }
}