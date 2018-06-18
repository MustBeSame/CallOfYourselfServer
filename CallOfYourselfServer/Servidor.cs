using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace CallOfYourselfServer
{
    class Servidor
    {
        Socket listener { get; set; }
        IPHostEntry ipHostInfo { get; set; }
        IPAddress ipAddress { get; set; }
        IPEndPoint localEndPoint { get; set; }
        List<Table> tables { get; set; }
        Socket handler { get; set; }
        public char[] data = null;
        byte[] bytes = new Byte[1024];
        char[] deck = {  'A', 'A',
                         'B', 'B', 'B',
                         'C', 'C',
                         'D', 'D',
                         'E', 'E',
                         'F', 'F',
                         'G', 'G',
                         'H', 'H',
                         'I', 'I',
                         'J', 'J',
                         'K', 'K', 'K', 'K', 'K',
                         'L', 'L',
                         'M', 'M',
                         'N', 'N',
                         'O', 'O',
                         'P', 'P',
                         'Q', 'Q', 'Q', 'Q', 'Q',
                         'R', 'R', 'R', 'R', 'R',
                         'S', 'S',
                         'T', 'T' };

        public void startServer()
        {
            ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            ipAddress = ipHostInfo.AddressList[0];
            localEndPoint = new IPEndPoint(ipAddress, 11000);
            listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(localEndPoint);
            tables = new List<Table>(0);
            listener.Listen(100);
        }

        public void listen()
        {
            handler = listener.Accept();

            int bytesRec = handler.Receive(bytes);
            data = Encoding.ASCII.GetChars(bytes, 0, bytesRec);

            processMessages(data);
            
        }

        private void processMessages(char[] inMessage)
        {
            switch (inMessage[0])
            {
                case '0':
                    processCreateTable(inMessage);
                    break;
                case '1':
                    processJoinTable(inMessage);
                    break;
                case '2':
                    processPlay(inMessage);
                    break;
                case '3':
                    processDraw(inMessage);
                    break;
                default:
                    break;
            }
        }

        private void processCreateTable(char[] inMessage)
        {
            int qtdPlayers =(int)Char.GetNumericValue(inMessage[1]);
            int sizeIp = int.Parse(inMessage[2].ToString() + inMessage[3].ToString());
            StringBuilder ip =new StringBuilder();
            StringBuilder password = new StringBuilder();
            for (int i =0; i<sizeIp;i++)
            {
                ip.Append(inMessage[i+4]);
            }
            int sizePassword = int.Parse(inMessage[sizeIp+4].ToString());
            for(int i = 0;i<sizePassword;i++)
            {
                password.Append(inMessage[i + 5 + sizeIp]);
            }
            Table table = new Table(sortDeck());
            Player player = new Player(ip.ToString(), table.Players.Count, getHand(table.Deck));
            table.Id = tables.Count;
            table.Password = password.ToString();
            table.Players.Add(player);
            tables.Add(table);
            sendResponseCreateTable(player, table);
        }
        private void processJoinTable(char[] inMessage)
        {

        }
        private void processPlay(char[] inMessage)
        {

        }
        private void processDraw(char[] inMessage)
        {

        }
        private void sendResponseCreateTable(Player player, Table table)
        {
            MessagesLib.MsgTableCreateResponse response = new MessagesLib.MsgTableCreateResponse('0', 
                                                                                                 player.Id.ToString().ToCharArray()[0], 
                                                                                                 table.Id.ToString().ToCharArray()[0], 
                                                                                                 player.Hand);
            handler.Send(Encoding.ASCII.GetBytes(response.createMessage()));

            //handler.Shutdown(SocketShutdown.Both);
            //handler.Close();
        }

        private char[] getHand(Stack<char> deck)
        {
            List<char> hand = new List<char>(0);
            hand.Add(deck.Pop());
            hand.Add(deck.Pop());
            hand.Add(deck.Pop());
            hand.Add(deck.Pop());
            hand.Add(deck.Pop());
            return hand.ToArray();
        }

        public Stack<char> sortDeck()
        {
            for (int i = 0; i < deck.Length; i++)
            {
                char temp = deck[i];
                Random r = new Random();
                int rInt = r.Next(0, 100);
                int randomIndex = r.Next(i, deck.Length);
                deck[i] = deck[randomIndex];
                deck[randomIndex] = temp;
            }
            Stack<char> a = new Stack<char>(deck);
            return a;
        }
    }
}
