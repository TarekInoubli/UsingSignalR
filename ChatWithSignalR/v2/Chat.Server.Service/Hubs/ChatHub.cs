using Chat.Server.Contracts;
using Chat.Core;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Server.Service.Hubs
{
    public class ChatHub : Hub<IChatHub>
    {
        public async Task SendChatMessage(ChatMessage message)
        {
            await Clients.All.ReceiveChatMessage(message);
        }
    }
}
