namespace NetCoreChatRoom.Models.NetCoreChatRoomAPIService.GroupChatMessage
{
    public class SendMessageToGroupModel
    {
        public SendMessageToGroupModel(string connectionId, int codGroupChat, string fromUser, string message)
        {
            ConnectionId = connectionId;
            CodGroupChat = codGroupChat;
            FromUser = fromUser;
            Message = message;
        }

        public string ConnectionId { get; set; }
        public int CodGroupChat { get; set; }

        public string FromUser { get; set; }

        public string Message { get; set; }
    }
}