using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesLib
{
    class Card
    {
        public char IdCard { get; set; }
        public char IdTargetPlayer { get; set; }
        public char IdCardTarget { get; set; }

        public Card(char idCard, char idTargetPlayer, char idCardTarget)
        {
            IdCard = idCard;
            IdTargetPlayer = idTargetPlayer;
            IdCardTarget = idCardTarget;
        }
    }
}
