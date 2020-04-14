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

namespace server
{
    class ClientThread
    {
        Socket sc;
        int i;
        static Dictionary<string, string> _data =
        new Dictionary<string, string>
        {
            {"0","Zero"},
            {"1","One"},
            {"2","Two"},
            {"3","Three"},
            {"4","Four"},
            {"5","Five"},
            {"6","Six"},
            {"7","Seven"},
            {"8","Eight"},
            {"9","Nine"},
            {"10","Ten"},
        };
        public ClientThread(Socket sc,int i)
        {
            this.sc = sc;
            this.i = i;
            Thread gui = new Thread(new ThreadStart(guiDL));
            gui.Start();
            Thread nhan = new Thread(new ThreadStart(nhanDL));
            nhan.Start();
        }
        void guiDL()
        {
            NetworkStream ns = new NetworkStream(sc);
            StreamWriter sw = new StreamWriter(ns);
            while(true)
            {
                string st = Console.ReadLine();
                sw.WriteLine("From server: " + st);
                
                if (st.ToUpper().Equals("QUIT"))
                {
                    break;
                }
                else if (_data.ContainsKey(st))
                {
                    sw.WriteLine("Number you've entered: {0}", _data[st]);
                    sw.Flush();
                }
                else
                {
                    sw.WriteLine("Number is not valid !");
                    sw.Flush();
                }
            }
            Console.WriteLine("Ket thuc phien gui du lieu toi client {0}", i);
        }
        void nhanDL()
        {
            NetworkStream ns = new NetworkStream(sc);
            StreamReader sr = new StreamReader(ns);
            while(true)
            {
                string st = sr.ReadLine();
                Console.Write("From Client {0}: ", i);
                Console.WriteLine(st);
                if (st.ToUpper().Equals("QUIT"))
                    break;
            }
            Console.WriteLine("Ket thuc phien nhan du lieu tu client {0}", i);
        }
    }
}
