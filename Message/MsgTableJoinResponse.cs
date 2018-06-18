using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessagesLib
{
    public class MsgTableJoinResponse : Message
    {
        private char[] Hand { get; set; }

        public MsgTableJoinResponse(char tipo, char idPlayer, char[] cardsIds)
        {
            Tipo = tipo;
            IdPlayer = idPlayer;
            Hand = cardsIds;
        }

        public override char[] createMessage()
        {
            List<char> message = new List<char>();
            message.Add(Tipo);
            message.Add(IdPlayer);
            message.Add(IdTable);
            addArrayOnList(5, Hand, message);
            return message.ToArray();
        }
    }
}
