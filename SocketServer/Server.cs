using CustomLogger;
using CustomLogger.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketServer
{
    public class Server
    {
        public void CreateListener()
        {
            TcpListener tcpListener = null;
            IPAddress ipAddress = Dns.GetHostEntry("localhost").AddressList[1];
            try
            {
                tcpListener = new TcpListener(ipAddress, 13);
                tcpListener.Start();
                EventLogger.Log(LogTarget.CONSOLE, LogLevel.INFO, "Waiting for a connection...");
                EventLogger.Log(LogTarget.FILE, LogLevel.INFO, "Waiting for a connection...");

            }
            catch (Exception e)
            {
                EventLogger.Log(LogTarget.FILE, LogLevel.WARNING, "Error: " + e.ToString());
            }
            while (true)
            {
                Thread.Sleep(10);
                TcpClient tcpClient = tcpListener.AcceptTcpClient();
                byte[] bytes = new byte[256];
                NetworkStream stream = tcpClient.GetStream();
                stream.Read(bytes, 0, bytes.Length);
                SocketHelper helper = new SocketHelper();
                helper.processMsg(tcpClient, stream, bytes);
                EventLogger.Log(LogTarget.CONSOLE, LogLevel.INFO, "Connection made!");
            }
        }
    }
}
