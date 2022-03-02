using Microsoft.AspNetCore.SignalR;

namespace NetCoreChatRoom.Services
{
    public class SignalRService : Hub
    {
        public class ChatHub : Hub
        {
            public string GetConnectionId()
            {
                return Context.ConnectionId;
            }
        }

        public async Task AddToGroup(string groupName, string user)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("EnteredOrLeft",
                $"{Context.ConnectionId} has" +
                $" joined the group {groupName}.");
        }
    }
}