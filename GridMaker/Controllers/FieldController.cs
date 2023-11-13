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

        public static Border AddPlayerToField()
        {
            Border border = new Border();
            border.Width = 30;
            border.Height = 30;
            border.CornerRadius = new System.Windows.CornerRadius(25);
            border.BorderBrush = Brushes.Black;
            border.BorderThickness = new System.Windows.Thickness(2);
            border.Background = Brushes.Transparent;
            border.Margin = new System.Windows.Thickness(0);

            return border;
        }
    }
}
