using Microsoft.AspNetCore.SignalR;

namespace IReadingWeb.Hubs
{
    public class ChatHub : Hub
    {
        public async Task JoinRoom(string roomName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
            await Clients.Group(roomName).SendAsync("ReceiveMessage", "Hệ thống", $"{Context.ConnectionId} đã tham gia {roomName}");
        }

        public async Task LeaveRoom(string roomName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
            await Clients.Group(roomName).SendAsync("ReceiveMessage", "Hệ thống", $"{Context.ConnectionId} đã rời {roomName}");
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.Others.SendAsync("ReceiveMessage", user, message);
        }

        public async Task SendMessageToRoom(string roomName, string user, string message)
        {
            await Clients.Group(roomName).SendAsync("ReceiveMessageToRoom", user, message);
        }
    }
}
