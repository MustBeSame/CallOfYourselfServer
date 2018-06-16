using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesLib
{
    class MsgTableCreateRequest : Message
    {
        private char QtdPlayers { get; set; }
        private char[] Password { get; set; }
        protected char[] IpPlayer { get; set; }

        public MsgTableCreateRequest(char tipo, char[] ipPlayer, char qtdPlayers, char[] password)
        {
            Tipo = tipo;
            IpPlayer = ipPlayer;
            QtdPlayers = qtdPlayers;
            Password = password;
        }

        public override char[] createMessage()
        {
            List<char> message = new List<char>();
            message.Add(Tipo);
            message.Add(QtdPlayers);
            message.Add(IpPlayer.Length.ToString().ToCharArray()[0]);
            message.Add(IpPlayer.Length.ToString().ToCharArray()[1]);
            addArrayOnList(IpPlayer.Length, IpPlayer, message);
            message.Add(Password.Length.ToString().ToCharArray()[0]);
            addArrayOnList(Password.Length, Password, message);
            return message.ToArray();
        }
    }
}
