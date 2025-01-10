using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPServerApp
{
    internal class Program
    {
        const int listtenPort = 11000;
        const string host = "127.0.0.1";
        static void Main(string[] args)
        {
            Thread thread = new Thread(new ThreadStart(StartListener));
            thread.Start();
        }

        private static void StartListener()
        {
            string message;
            UdpClient listener = new UdpClient(listtenPort);
            IPAddress address = IPAddress.Parse(host);
            IPEndPoint remoteEndpoint = new IPEndPoint(address, listtenPort);
            Console.Title = "UDP Server";
            Console.WriteLine(new string('*', 40));
            try
            {
                while (true)
                {
                    Console.WriteLine("Waiting for broadcast");
                    byte[] bytes = listener.Receive(ref remoteEndpoint);
                    message = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                    Console.WriteLine($"Received broadcast from {remoteEndpoint}:{message}");
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                listener.Close();
            }
        }
    }
}
