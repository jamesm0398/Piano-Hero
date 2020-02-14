using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net;
using System.IO;
using System.Threading;
using System.Net.Sockets;

//Class: Server
//Summary: This class acts as a server for listening for new microcontroller connections

namespace PianoHeroDesktopApp
{
    class Server
    {
        TcpListener server = null;
        public Server(string ip, int port)
        {
            IPAddress localAddr = IPAddress.Parse(ip);
            server = new TcpListener(localAddr, port);
            server.Start();
            StartListener();
        }

        //StartListener
        //Summary: Start listening for new connections on a separate thread
        public void StartListener()
        {
            try
            {
                while (true)
                {
                    
                    TcpClient client = server.AcceptTcpClient();
                    
                    Thread t = new Thread(new ParameterizedThreadStart(HandleNewConnection));
                    t.Start(client);
                }
            }
            catch (SocketException e)
            {
                //Show error message
                server.Stop();
            }
        }

        //HandleNewConnection
        //Summary: Handles new microcontroller connection, parses its name
        //Params: Object obj: New connection object (thread)
        //Returns: none
        public void HandleNewConnection (Object obj)
        {
            TcpClient client = (TcpClient)obj;
            var stream = client.GetStream();
            
            string data = null;
            Byte[] bytes = new Byte[256];
            int i;

            try
            {
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    string hex = BitConverter.ToString(bytes);
                    data = Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine("{1}: Received: {0}", data, Thread.CurrentThread.ManagedThreadId);
                    //Parse microcontroller name
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.ToString());
                client.Close();
            }




        }
    }
}
