using Chat.SignalR.Hubs;

namespace Chat.SignalR
{
    public static class ServiceConfig
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ChatHub>();
        }
    }
}
