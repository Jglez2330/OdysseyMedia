using System.Net;
using System.Xml.Linq;
using System.Text;
using System;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Threading;

namespace Odyssey
{
    public class SocketClient

    {


        private Socket socket;
        private static SocketClient SocketClientInstance;
        private string ip = "192.168.0.15";

        private SocketClient()
        {
            try
            {


                IPHostEntry ipHostInfo = Dns.GetHostEntry(ip);//Dns.GetHostName());  
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint ipEndpoint = new IPEndPoint(ipAddress, 5555);
                socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(ipEndpoint);
                Console.WriteLine("Socket created to {0}", socket.RemoteEndPoint.ToString());

                

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

            }
        }
        public static SocketClient GetSocketClient()
        {
            if (SocketClientInstance == null)
            {
                SocketClientInstance = new SocketClient();
            }
            return SocketClientInstance;
        }

        public void send(string jsonMessage)
        {
            byte[] message = Encoding.UTF8.GetBytes(jsonMessage + "\nP");
            this.socket.Send(message);
            
        }

        public string Listen()
        {
            byte[] trash = new byte[1];
            var buffer = new List<byte>();
            var currByte = new Byte[1];
            while (true)
            {

                var byteCounter = socket.Receive(currByte, currByte.Length, SocketFlags.None);
                if (currByte[0] == 1)
                {
                    break;
                }
                else
                {
                    buffer.Add(currByte[0]);
                }
            }
            while (socket.Available != 0)
            {
                socket.Receive(trash);
            }
            string json = System.Text.Encoding.UTF8.GetString(buffer.ToArray());
            return json;


        }
    }
}