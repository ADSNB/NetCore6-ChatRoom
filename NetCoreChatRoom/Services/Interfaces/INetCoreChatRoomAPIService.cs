using NetCoreChatRoom.Models.NetCoreChatRoomAPIService.GroupChat;
using NetCoreChatRoom.Models.NetCoreChatRoomAPIService.GroupChatMessage;

namespace NetCoreChatRoom.Services.Interfaces
{
    public interface INetCoreChatRoomAPIService
    {
        public Task<Object?> Get();

        public Task<object?> SendMessage(string user, string message);

        public Task<object> GetAllGroupChat();

        public Task<object> GetLastGroupChatMessage(GetLastGroupChatMessageModel inputModel);

        public Task<object> SendMessageToGroup(SendMessageToGroupModel model);

        public Task<object> CreateGroupChat(CreateGroupChatModel model);
    }
}