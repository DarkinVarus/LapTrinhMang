using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.IO;
using System.Threading;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket socketclient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            socketclient.Connect(iep);
            new ClientThread(socketclient);
            Console.WriteLine("Da ket noi den server!");
            Console.WriteLine("Xin moi nhap so tu 0-10");
        }
    }
}
