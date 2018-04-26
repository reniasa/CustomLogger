using System.Net.Sockets;
using System.Text;

namespace SocketServer
{
    class SocketHelper
    {
        byte[] bytesSent;
        public void processMsg(TcpClient client, NetworkStream stream, byte[] bytesReceived)
        {
            var messageReceived = Encoding.ASCII.GetString(bytesReceived, 0, bytesReceived.Length).Replace("\0", string.Empty);
    
            //Sending back the same message
            bytesSent = Encoding.ASCII.GetBytes(messageReceived.Trim());
            stream.Write(bytesSent, 0, bytesSent.Length);
        }
    }
}
