using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridMaker.Model.Repo
{
    public class PlayerRepo
    {
        private Dictionary<string, Player> ListOfAllPlayers = new();
        private Dictionary<int, Point> ListOfOffensiveFormation = new();
        private Dictionary<int, Point> ListOfDefensiveFormation = new();

        public void SavePlayer(Player player)
        {
            ListOfAllPlayers.Add(player.Id, player);
        }

        public Player? FindPlayer(string id)
        {
            Player? result = null;
            foreach (var key in ListOfAllPlayers)
            {
                if (key.Value.Equals(id))
                {
                    result = key.Value;
                }
                else
                {
                    result = null;
                    throw new Exception("Player could not be found.");
                }

            }
            return result;
        }

        public void RemovePlayer(Player player)
        {
            ListOfAllPlayers.Remove(player.Id);
        }
    }
}
