using Chat.Console;
using Chat.Console.Services;
using Chat.Domain.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.ObjectModel;

// Connect to the Hub
HubConnection connection = new HubConnectionBuilder()
    .WithUrl("https://localhost:7159/chat")
    .Build();

Helper helper = new Helper(new SignalRChatService(connection));

Console.WriteLine("Client Started");
Console.WriteLine("To quit type exit");
Console.WriteLine("Type Message:");
while (true)
{
        
    string? line = Console.ReadLine();

    if (line?.ToLower() == "exit")
    {
        break;
    }

    await helper.SendMessage(line);
}

