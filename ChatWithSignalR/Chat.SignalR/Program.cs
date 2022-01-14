using Chat.SignalR.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add SignalR Middleware services
builder.Services.AddSignalR();

var app = builder.Build();

// Add the Hub as an endpoint
app.MapHub<ChatHub>("/chat");

app.Run();
