using Chat.Core;

namespace Chat.Server.Contracts
{
    public interface IChatHub
    {
        Task ReceiveChatMessage(ChatMessage message);
    }
}
