using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesLib
{
    class MsgPlayRequest : Message
    {
        private List<Card> Play { get; set; }
        
        public void addPlay(char idCard, char idTargetPlayer, char idCardTarget)
        {
            Play.Add(new Card(idCard, idTargetPlayer, idCardTarget));
        }

        public override char[] createMessage()
        {
            List<char> message = new List<char>();
            message.Add(Tipo);
            message.Add(IdTable);
            message.Add(IdPlayer);
            message.Add(Play.Count.ToString().ToCharArray()[0]);
            addArrayOnList(Play.Count, Play.ToArray(), message);
            return message.ToArray();
        }

        private void addArrayOnList(int length, Card[] cards, List<char> list)
        {
            for (int i = 0; i < length; i++)
            {
                list.Add(cards[i].IdCard);
                list.Add(cards[i].IdCardTarget);
                list.Add(cards[i].IdTargetPlayer);
            }
        }
    }
}
