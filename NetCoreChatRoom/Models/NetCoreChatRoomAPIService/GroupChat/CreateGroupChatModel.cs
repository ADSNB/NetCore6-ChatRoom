namespace NetCoreChatRoom.Models.NetCoreChatRoomAPIService.GroupChat
{
    public class CreateGroupChatModel
    {
        public CreateGroupChatModel(string connectionId, string name, string description, string createdByUser)
        {
            ConnectionId = connectionId;
            Name = name;
            Description = description;
            CreatedByUser = createdByUser;
        }

        public string ConnectionId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedByUser { get; set; }
    }
}