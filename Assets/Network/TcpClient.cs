using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;

namespace Assets.Network
{
    public class TcpClient 
    {
        public static void Connect(string ipAddress)
        {

        }
        public static void Connect(string ipAddress, ushort port)
        {

        }
        public static ServerStatus GetStatus(string ipAddress)
        {
            return null;
        }
    }

    public class ServerStatus
    {
        public string version {get; private set;} = "";
        public string description {get; private set;} = "";
        public uint connected {get; private set;} = 0;
        public uint maxConnections {get; private set;} = 0;
        public string address {get; private set;} = "localhost";
    }
}