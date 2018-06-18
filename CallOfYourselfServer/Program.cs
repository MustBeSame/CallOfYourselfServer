using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagesLib;

namespace CallOfYourselfServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Servidor theServer = new Servidor();
            theServer.startServer();
            while (true)
            {
                theServer.listen();
            }
        }
    }
}
