using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridMaker.Repo
{
    public class PlayerRepo
    {
        private Dictionary<string, Player> ListOfAllPlayers = new();

        public void AddToList_AllPlayers(string guid, Player player)
        {
            ListOfAllPlayers.Add(guid, player);
        }

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
                } else
                {
                    result = null;
                    MessageBox.Show("Player could not be found", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
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
