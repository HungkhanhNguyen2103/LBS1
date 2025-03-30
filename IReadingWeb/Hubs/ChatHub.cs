using IReadingWeb.Service.UserConnection;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using System.Security.Claims;

namespace IReadingWeb.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IUserConnectionManager _manager;

        public ChatHub(IUserConnectionManager manager)
        {
            _manager = manager;
        }

        public override async Task OnConnectedAsync()
        {
            var userName = Context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var roomName = Context.User.FindFirst(ClaimTypes.GroupSid).Value;
            _manager.AddConnection(userName, Context.ConnectionId);
            var connections = _manager.GetConnections(userName);
            var roomNameList = roomName.Split(",");
            foreach (var connectionId in connections)
            {
                foreach (var rName in roomNameList)
                {
                    await Groups.AddToGroupAsync(connectionId, rName);
                    await Clients.Group(rName).SendAsync("ReceiveMessage", "System", $"{userName} đã tham gia {rName}");
                }

            }
            //await Clients.All.SendAsync("ReceiveMessage", "System", $"{userName} đã hoạt động");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            _manager.RemoveConnection(Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);

        }

        public async Task ForceDisconnect(string roomName)
        {
            _manager.RemoveConnection(Context.ConnectionId);
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        }

        //public async Task JoinRoom(string roomName)
        //{
        //    var userName = Context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        //    var connections = _manager.GetConnections(userName);
        //    foreach (var connectionId in connections)
        //    {
        //        await Groups.AddToGroupAsync(connectionId, roomName);
        //        await Clients.Group(roomName).SendAsync("ReceiveMessage", "Hệ thống", $"{userName} đã tham gia {roomName}");
        //    }
            
        //}

        //public async Task LeaveRoom(string roomName)
        //{
        //    await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        //    await Clients.Group(roomName).SendAsync("ReceiveMessage", "Hệ thống", $"{Context.ConnectionId} đã rời {roomName}");
        //}

        public async Task SendMessage(string user, string message)
        {
            await Clients.Others.SendAsync("ReceiveMessage", user, message);
        }

        public async Task SendMessageToRoom(string roomName, string message)
        {
            var userName = Context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await Clients.OthersInGroup(roomName).SendAsync("ReceiveMessage", roomName, message);
            await _manager.SendMessage(new BusinessObject.Messenger
            {
                Content = message,
                CreateBy = userName,
                RoomId = roomName
            });
        }
    }
}
