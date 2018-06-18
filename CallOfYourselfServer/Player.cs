using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CallOfYourselfServer
{
    class Player
    {
        public Player(string ip, int id, char[] hand)
        {
            Ip = ip;
            Id = id;
            Hand = hand;
        }

        public string Ip { get; set; }
        public int Id { get; set; }
        public char[] Hand { get; set; }

    }
}
