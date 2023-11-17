using GridMaker.Model;
using GridMaker.Model.Repo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridMaker.ViewModel.Controllers
{
    public class PlayerController
    {
        public PlayerRepo playerRepo;

        public void AddNewPlayer(string position, string text)
        {
            Player player = new Player() { Position = position };
            playerRepo.SavePlayer(player);
        }

        public void RemovePlayer(ref Player player)
        {
            playerRepo.RemovePlayer(player);
        }

        public Player? FindPlayer(string id)
        {
            return playerRepo.FindPlayer(id);
        }

        public void SaveRoute(Point[] points)
        {

        }
    }
}
