using System;
using GridMaker.ViewModel.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridMaker.Model
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
