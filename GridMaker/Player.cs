using System;
using GridMaker.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;

namespace GridMaker
{
    public class Player
    {
        private string _id = null;

        public Player()
        {
            string guid = Guid.NewGuid().ToString();
            string _newid = new string(guid.Insert(0, "B").Replace('-', 'B'));
            _id = _newid;
        }
        public string Id
        {
            get { return _id; }
        }
    }
}
