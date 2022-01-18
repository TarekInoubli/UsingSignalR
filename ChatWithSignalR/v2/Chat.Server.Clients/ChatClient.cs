using Chat.Core;
using Chat.Server.Contracts;
using Microsoft.AspNetCore.SignalR.Client;

namespace Chat.Server.Clients
{
    public class ChatClient
    {
        private readonly HubConnection hubConnection;

        public ChatClient()
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl(Constants.ChatHubConnection)
                .Build();

            // Register to hub event
            hubConnection.On<ChatMessage>(nameof(IChatHub.ReceiveChatMessage), OnChatMessageReceived);

            // Connect to hub
            _ = ConnectToHub();
        }

        public event EventHandler<ChatMessage>? ChatMessageReceived;

        public async Task SendMessage(ChatMessage message)
        {
            await EnsureHubConnection();
            await hubConnection.SendAsync(nameof(IChatToHub.SendChatMessage), message);
        }

        private async Task EnsureHubConnection()
        {
            await ConnectToHub();
        }

        private async Task ConnectToHub()
        {
            if (hubConnection.State != HubConnectionState.Connected)
            {
                await hubConnection.StartAsync();
            }
        }

        private void OnChatMessageReceived(ChatMessage message)
        {
            ChatMessageReceived?.Invoke(this, message);
        }
    }
}