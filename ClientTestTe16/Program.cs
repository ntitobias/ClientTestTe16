using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientTestTe16
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string address = "127.0.0.1";
                int port = 8001;

                //Anslut till server
                Console.WriteLine("Ansluter...");
                TcpClient tcpClient = new TcpClient();
                tcpClient.Connect(address, port);
                Console.WriteLine("Ansluten!");

                //Skriv meddelande att skicka
                Console.Write("Skriv meddelande: ");
                string message = Console.ReadLine();

                //Konvertera meddelande till UTF8-bytes
                Byte[] bMessage =
                    System.Text.Encoding.UTF8.GetBytes(message);

                //Skicka iväg meddelandet
                Console.WriteLine("Skickar...");
                NetworkStream tcpStream = tcpClient.GetStream();
                tcpStream.Write(bMessage, 0, bMessage.Length);
                tcpClient.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.ReadLine();
        }
    }
}
