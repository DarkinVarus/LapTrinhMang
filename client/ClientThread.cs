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
    class ClientThread
    {
        Socket s;
        public ClientThread(Socket s)
        {
            this.s = s;
            Thread gui = new Thread(new ThreadStart(guiDL));
            gui.Start();
            Thread nhan = new Thread(new ThreadStart(nhanDL));
            nhan.Start();
        }
        
        void guiDL()
        {
            NetworkStream ns = new NetworkStream(s);
            StreamWriter sw = new StreamWriter(ns);
            while(true)
            {
                
                string st = Console.ReadLine();
                sw.WriteLine(st);
                sw.Flush();
                if(st.ToUpper().Equals("QUIT"))
                {
                    Console.WriteLine("Ban da ngat ket noi voi server!");
                    break;
                }
            }
            sw.Close();
            ns.Close();
        }
        void nhanDL()
        {
            NetworkStream ns = new NetworkStream(s);
            StreamReader sr = new StreamReader(ns);
            while(true)
            {
                string st = sr.ReadLine();
                Console.WriteLine(st);
                if (st.ToUpper().Equals("QUIT"))
                    break;
            }
            sr.Close();
            ns.Close();
        }
    }
}
