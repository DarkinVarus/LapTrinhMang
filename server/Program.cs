using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Net.WebSockets;

namespace server
{
    public class Program
    {
        static void Main(string[] args)
        {
            Socket socketserver = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Any, 8080);
            socketserver.Bind(iep);
            Console.WriteLine("Dang cho ket noi tu client...");
            socketserver.Listen(10);
            int i = 0;
            while(true)
            {
                i++;
                Socket socketclient = socketserver.Accept();
                Console.WriteLine("Client {0} da ket noi", i);
                new ClientThread(socketclient, i);
            }
        }
    }
}
