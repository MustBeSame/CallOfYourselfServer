using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesLib
{
    class MsgTableCreateResponse : Message
    {
        
        private char[] Hand { get; set; }

        public MsgTableCreateResponse(char tipo, char idPlayer, char idTable, char[] cardsIds)
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
