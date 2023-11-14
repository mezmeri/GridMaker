using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GridMaker.Controllers
{
    public partial class FieldController
    {

        public void AddToList(Player player)
        {

        }   

        public static string GenerateUniqueIdentifier()
        {
            string guid = Guid.NewGuid().ToString();
            string _id = new string(guid.Insert(0, "B").Replace('-', 'B'));

            return _id;
        }
    }
}
