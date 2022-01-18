using Chat.Core;

namespace Chat.Server.Contracts
{
    public interface IChatToHub
    {
        Task SendChatMessage(ChatMessage message);
    }
}
