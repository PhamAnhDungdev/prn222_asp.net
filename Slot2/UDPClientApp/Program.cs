using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPClientApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string host = "127.0.0.1";
            int port = 11000;
            ConnectServer(host, port);
            Console.Read();
        }

        static void ConnectServer(string host, int port)
        {
            UdpClient client = new UdpClient();
            IPAddress address = IPAddress.Parse(host);
            IPEndPoint remoteEndpoint = new IPEndPoint(address, port);
            string message;
            int count = 0;
            bool done = false;
            Console.Title = "UDP Client";
            try
            {
                Console.WriteLine(new string('*', 40));
                client.Connect(remoteEndpoint);
                while(!done)
                {
                    message = $"Message {++count:D2}";
                    byte[] sendBytes = Encoding.ASCII.GetBytes(message);
                    client.Send(sendBytes, sendBytes.Length);
                    Console.WriteLine($"Sent: {message}");
                    Thread.Sleep(200);
                    if(count == 10)
                    {
                        done = true;
                        Console.WriteLine("Done.");
                    }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                client.Close();
            }
        }
    }
}
