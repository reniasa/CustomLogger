using CustomLogger.Enums;
using CustomLogger.Interfaces;
using System;
using System.Diagnostics.Contracts;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace CustomLogger.Outputters
{
    public class SocketOutputter : LogBase, IOutputter
    {
        public void Log(string message, LogLevel logLevel)
        {
            string serverIP = "localhost";
            Client.Connect(serverIP, message);
        }

    }

    internal class Client
    {
        internal static void Connect(string serverIP, string message)
        {
            try
            {
                var port = 13;
                TcpClient client = new TcpClient(serverIP, port);

                var data = Encoding.ASCII.GetBytes(message);

                NetworkStream stream = client.GetStream();

                stream.Write(data, 0, data.Length);

                EventLogger.Log(LogTarget.FILE, LogLevel.INFO, "Sent: " + message);

                data = new byte[256];

                var bytes = stream.Read(data, 0, data.Length);
                var responseData = Encoding.ASCII.GetString(data, 0, bytes);
                EventLogger.Log(LogTarget.FILE, LogLevel.INFO, "Received: " + responseData);

                Contract.Requires(message == responseData);

                stream.Close();
                client.Close();
            }
            catch (ArgumentNullException e)
            {
                EventLogger.Log(LogTarget.FILE, LogLevel.INFO, "ArgumentNullException: " + e);
            }
            catch (SocketException e)
            {
                EventLogger.Log(LogTarget.FILE, LogLevel.INFO, "SocketException: " + e.ToString());
            }
        }
    }
}
