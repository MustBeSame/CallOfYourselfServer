using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CallOfYourselfServer
{
    class Table
    {
        public Table(Stack<char> deck)
        {
            Players = new List<Player>(0);
            Deck = deck;
        }

        public List<Player> Players { get; set; }
        public int Id {get;set;}
        public String Password { get; set; }
        public int QtdPlayers;
        public Stack<char> Deck;

    }
}
