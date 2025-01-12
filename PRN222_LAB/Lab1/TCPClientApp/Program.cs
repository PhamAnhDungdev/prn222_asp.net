using System.Net.Sockets;
using System.Net;

namespace TCPClientApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server APP - Lab1");
            string host = "127.0.0.1";
            int port = 8080;
            ExecuteServer(host, port);
        }
        static void ProcessMessage(object parm)
        {
            string data;
            int count;
            try
            {
                TcpClient client = parm as TcpClient;
                //New buffer read data
                Byte[] bytes = new Byte[256];

                //Get a stream object for reading and writing
                NetworkStream stream = client.GetStream();

                // Lặp qua tất cả dữ liệu nhận được từ client
                while ((count = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, count);
                    Console.WriteLine($"Received: {data} at {DateTime.Now:t}");

                    data = $"{data.ToUpper()}";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                    stream.Write(msg, 0, msg.Length);
                    Console.WriteLine($"Sent: {data}");
                }
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
                Console.WriteLine("Waiting message...");
            }
        }
        static void ExecuteServer(string host, int port)
        {
            int Count = 0;
            TcpListener server = null;
            try
            {
                Console.Title = "Server Application";
                IPAddress localAdd = IPAddress.Parse(host);
                server = new TcpListener(localAdd, port);
                server.Start();
                Console.WriteLine(new String('*', 40));
                Console.WriteLine("Waiting for a connection...");

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine($"Number of client connected: {++Count}");
                    Console.WriteLine(new string('*', 40));
                    Thread thread = new Thread(new ParameterizedThreadStart(ProcessMessage));
                    thread.Start(client);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);
            }
            finally
            {
                server.Stop();
                Console.WriteLine("Server stopped. Pres any key to exits !");
            }
            Console.Read();
        }
    }
}
