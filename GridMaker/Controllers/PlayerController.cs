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
        public static Border CreateNewPlayer()
        {
            PlayerRepo repo = new PlayerRepo();
            Player player = new Player();
            Border playerBorder = new Border();
            playerBorder.Name = player.Id.ToString();
            playerBorder.Width = 30;
            playerBorder.Height = 30;
            playerBorder.CornerRadius = new CornerRadius(25);
            playerBorder.BorderBrush = Brushes.Black;
            playerBorder.BorderThickness = new Thickness(2);
            playerBorder.Background = Brushes.Transparent;
            playerBorder.Margin = new Thickness(0);

            repo.AddToList_AllPlayers(player.Id, player);

            return playerBorder;
        }
    }
}
