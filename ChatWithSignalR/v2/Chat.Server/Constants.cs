namespace Chat.Server
{
    public static class Constants
    {
        public const string ChatHub = "/ChatHub";
        public const string ServiceConnection = "https://localhost:7159";
        public static string ChatHubConnection = $"{ServiceConnection}{ChatHub}";
    }
}