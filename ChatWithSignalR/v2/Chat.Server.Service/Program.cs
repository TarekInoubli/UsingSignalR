using Chat.Server;
using Chat.Server.Service.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add SignalR Middleware services
builder.Services.AddSignalR();

var app = builder.Build();

// Map SignalR Hub endpoints
app.MapHub<ChatHub>(Constants.ChatHub);

app.Run();
