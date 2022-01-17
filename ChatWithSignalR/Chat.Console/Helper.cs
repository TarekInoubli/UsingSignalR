using Chat.Console.Services;
using Chat.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Console
{
    public class Helper
    {
        private readonly SignalRChatService _chatService;

        public Helper(SignalRChatService chatService)
        {
            _chatService = chatService;
            _chatService.Connect().ContinueWith(task =>
            {
                if (task.Exception != null)
                {
                    System.Console.WriteLine("Unable to connect to chat hub!");
                } 
            });
            _chatService.MessageReceived += _chatService_MessageReceived;
        }

        private void _chatService_MessageReceived(Message obj)
        {
            System.Console.WriteLine($"{obj.Body}");
        }

        public async Task SendMessage(string? message)
        {
            if (message == null) return;

            await _chatService.SendMessage(new Message()
            {
                Body = message
            });
        }
    }
}
