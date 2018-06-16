using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesLib
{
    class MsgTableJoinRequest : Message
    {
        private char[] Password { get; set; }
        protected char[] IpPlayer { get; set; }

        public MsgTableJoinRequest(char tipo, char idOrigem, char table, char[] ipPlayer, char[] password)
        {
            Tipo = tipo;
            IpPlayer = ipPlayer;
            Password = password;
        }

        public override char[] createMessage()
        {
            List<char> message = new List<char>();
            message.Add(Tipo);
            message.Add(IdTable);
            message.Add(IpPlayer.Length.ToString().ToCharArray()[0]);
            message.Add(IpPlayer.Length.ToString().ToCharArray()[1]);
            addArrayOnList(IpPlayer.Length, IpPlayer, message);
            message.Add(Password.Length.ToString().ToCharArray()[0]);
            addArrayOnList(Password.Length, Password, message);
            return message.ToArray();
        }
    }
}
