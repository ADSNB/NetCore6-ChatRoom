namespace NetCoreChatRoom.Models.NetCoreChatRoomAPIService.GroupChatMessage
{
    public class GetLastGroupChatMessageModel
    {
        public GetLastGroupChatMessageModel(int codGroupChat, int quantity)
        {
            CodGroupChat = codGroupChat;
            Quantity = quantity;
        }

        public int CodGroupChat { get; set; }
        public int Quantity { get; set; }
    }
}