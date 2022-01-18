using Chat.Domain.Models;
using Microsoft.AspNetCore.SignalR;

namespace Chat.SignalR.Hubs
{
    public class StronglyTypedChatHub : Hub<IChatClient>
    {
        public async Task SendChatMessage(Message message)
        {
            await Clients.All.ReceiveChatMessage(message);
        }
    }
}
