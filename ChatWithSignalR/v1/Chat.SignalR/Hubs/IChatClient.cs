using Chat.Domain.Models;

namespace Chat.SignalR.Hubs
{
    public interface IChatClient
    {
        Task ReceiveChatMessage(Message message);
    }
}
