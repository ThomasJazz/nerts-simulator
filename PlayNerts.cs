using System;
using System.Collections.Generic;
using System.Linq;

namespace nerts_simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>();
            
            players.Add(new Player("Thomas"));
            players.Add(new Player("Grace"));
            players.Add(new Player("Maguire"));
            players.Add(new Player("Joy"));

            int numPlayers = players.Count;

            foreach (Player player in players)
            {
                player.CreateNewDeck();
                Console.WriteLine(player.ToString());
            }
            Console.WriteLine();
        }
    }
}
