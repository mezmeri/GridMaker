using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridMaker
{
    public class Field
    {
        private static double _width = 0;
        private static double _height = 0;

        public static double Width { get { return _width; } set { _width = value; } }
        public static double Height { get { return _height; } set {  _height = value; } }
    }
}
