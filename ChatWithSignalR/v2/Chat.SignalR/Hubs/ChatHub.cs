using Chat.Domain.Models;
using Microsoft.AspNetCore.SignalR;

namespace Chat.SignalR.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendChatMessage(Message message)
        {
            await Clients.All.SendAsync("ReceiveChatMessage", message);
        }
    }
}
