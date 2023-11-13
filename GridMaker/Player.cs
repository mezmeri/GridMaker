using System;
using GridMaker.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridMaker
{
    public class Player
    {
        private string _id = null;
        private string _position = null;

        public Player()
        {
            _id = Guid.NewGuid().ToString();
        }

        public string Position
        {
            set { _position = value; }
        }

        public string Id
        {
            get { return _id; }
        }
    }
}
