using Microsoft.AspNetCore.SignalR;

namespace BlazorAppDemo.Components.Hubs
{
    /// <summary>
    /// DB接続のためのHub
    /// </summary>
    public class ConnectionHub : Hub
    {
        public async Task SendMessageClientsAll(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}