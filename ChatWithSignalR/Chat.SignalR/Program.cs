using Chat.SignalR.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add SignalR Middleware services
builder.Services.AddSignalR();

var app = builder.Build();

// Setup SignalR routes
app.MapHub<ChatHub>("/chat");

app.Run();
