using System.Net.Sockets;

namespace TCPServerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client APP - Lab1");
            string server = "127.0.0.1";
            int port = 8080;
            ConnectServer(server, port);
        }


        static void ConnectServer(string server, int port)
        {
            string message, responseData;
            int bytes;
            try
            {
                TcpClient client = new TcpClient(server, port);
                Console.Title = "Client Application";
                NetworkStream stream = null;
                while (true)
                {
                    Console.WriteLine("Input message <press Enter to exit>: ");
                    message = Console.ReadLine();
                    if (message == string.Empty)
                    {
                        break;
                    }

                    Byte[] data = System.Text.Encoding.ASCII.GetBytes($"{message}");
                    stream = client.GetStream();
                    stream.Write(data, 0, data.Length);
                    Console.WriteLine("Sent: {0}", message);
                    data = new Byte[256];
                    bytes = stream.Read(data, 0, data.Length);
                    responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                    Console.WriteLine("Received: {0}", responseData);
                }
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
            }
        }
    }
}
