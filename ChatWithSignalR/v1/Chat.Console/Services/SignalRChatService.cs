using Chat.Domain.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Console.Services
{
    public class SignalRChatService
    {
        private readonly HubConnection _connection;

        public event Action<Message> MessageReceived; // To notify the application when we receive an event from the ChatHub (SignalR Server)

        public SignalRChatService(HubConnection connection)
        {
            _connection = connection;

            _connection.On<Message>("ReceiveChatMessage", (message) => MessageReceived?.Invoke(message));
        }

        public async Task Connect()
        {
            await _connection.StartAsync();
        }

        public async Task SendMessage(Message message)
        {
            await _connection.SendAsync("SendChatMessage", message); // The given methodName should match the method name in the ChatHub
        }
    }
}
