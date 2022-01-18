# UsingSignalR
***An example that explains how to use SignalR in ASP.NET Core***

## What is SignalR?
ASP.NET Core SignalR is an open-source library that simplifies the process of adding real-time web functionality to applications. It provides server-client communication asynchronously.
When there is a new or change in the data, the server informs instantly the clients.
Here are some features of SignalR for ASP.NET Core:
  - Handles connection management automatically
  - Sends messages to all connected clients simultaneously
  - Sends messages to specific clients or group of clients
  - Scales to handle increasing traffic

### Transports
SignalR supports the following techniques for handling real-time communication:
  - WebSockets
  - Server-Sent Events
  - Long Polling
SignalR automatically chooses the best transport method that is within the capabilities of the server and client.

### Hubs
SignalR uses *hubs* for the communication between servers and clients.
A hub is a high-level pipeline that allows a client and server to call methods on each other. In the server code, you define methods that are called by client. In the client code, you define methods that are called from the server.

## Usage
### Configure hubs
The SignalR middleware requires some services, which are configured by calling `services.AddSignalR`
```C#

// Add middleware services
services.AddSignalR();

```
*(see Program.cs in the Chat.SignalR)*

### Setup routes
After creating the SignalR hub in the Server, setup SignalR routes by calling `app.MapHub`
```C#

// Setup SignalR routes
app.MapHub<ChatHub>("/chat");

```
*(see Program.cs in the Chat.SignalR)*

### Create and use hubs
Create a hub by declaring a class that inherits from `Hub`, and add public methods to it. Clients can call methods that are defined as `public`.
```C#

using Chat.Domain.Models;
using Microsoft.AspNetCore.SignalR;

namespace Chat.SignalR.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendChatMessage(Message message)
        {
            await Clients.All.SendAsync("ReceiveChatMessage", message);
        }
    }
}

```
*(see ChatHub.cs in the Chat.SignalR)*

`SendChatMessage` method sends a message to all connected clients, using `Clients.All`.

You can specify a return type and parameters, including complex types and arrays, as you would in any C# method.
SignalR handles the serialization and deserialization of complex objects and arrays in your parameters and return values.

> ❕ **Note**
>  * Don't store state in a property on the hub class. Every hub method call is executed on a new hub instance.
>  * Use `await` when calling asynchronous methods to avoid failures.

### Strongly typed hubs
A drawback of using `SendAsync("ReceiveChatMessage", message)` is that is relies on a magic string to specify the client method to be called. This leaves code open to runtime errors 💥 if the method name is misspelled or missing from the client.

✔️ An alternative to using `SendAsync` is to strongly type the `Hub` with [`Hub<T>.`](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.signalr.hub-1?view=aspnetcore-6.0) In our example, ChatHub client methods have been extracted out into an interface called `IChatClient`

```C#

using Chat.Domain.Models;

namespace Chat.SignalR.Hubs
{
    public interface IChatClient
    {
        Task ReceiveChatMessage(Message message);
    }
}

```
*(see IChatClient.cs in the Chat.SignalR)*

`IChatClient` can be used to refactor the preceding `ChatHub`.

```C#

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
```
*(see StronglyTypedChatHub.cs in the Chat.SignalR)*

Using `Hub<IChatClient>` enables compile-time checking of the client methods. This prevents issues caused by using magic strings.

## Start Application
![image](https://user-images.githubusercontent.com/5670324/149818132-39131038-25fc-4753-bf89-272df74323b3.png)


  
