using GridMaker.Repo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GridMaker.Controllers
{
    public class PlayerController
    {
        public PlayerRepo playerRepo;

        public static Border CreateNewPlayer()
        {
            Border player = new();
            player.Name = FieldController.GenerateUniqueIdentifier();
            player.Width = 30;
            player.Height = 30;
            player.CornerRadius = new CornerRadius(25);
            player.BorderBrush = Brushes.Black;
            player.BorderThickness = new Thickness(2);
            player.Background = Brushes.Transparent;
            player.Margin = new Thickness(0);

            return player;
        }
    }
}
