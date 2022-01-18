using Chat.Core;
using Chat.Server.Clients;

namespace Chat.Client.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ChatClient client = new ChatClient();
            client.ChatMessageReceived += Client_ChatMessageReceived;
            System.Console.WriteLine("Client Started");
            System.Console.WriteLine("To quit type exit");
            System.Console.WriteLine("Type Message:");

            while (true)
            {
                var line = System.Console.ReadLine();
                if (line?.ToLower() == "exit") break;

                _ = client.SendMessage(new ChatMessage()
                {
                    Message = line
                });
            }
        }

        private static void Client_ChatMessageReceived(object? sender, ChatMessage e)
        {
            System.Console.WriteLine($"{e.Message}");
        }
    }
}
