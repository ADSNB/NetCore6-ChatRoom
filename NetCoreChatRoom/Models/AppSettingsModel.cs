namespace NetCoreChatRoom.Models
{
    public class AppSettingsModel
    {
        public string WebSiteDomain { get; set; }
        public AzureAD AzureAD { get; set; }
        public NetCoreChatRoomAPI NetCoreChatRoomAPI { get; set; }
    }

    public class AzureAD
    {
        public string Instance { get; set; }
        public string Domain { get; set; }
        public string TenantId { get; set; }
        public string ClientId { get; set; }
        public string CallbackPath { get; set; }
    }

    public class NetCoreChatRoomAPI
    {
        public string BaseUrl { get; set; }
        public int ServiceTimeoutInMiliseconds { get; set; }
        public int LastGroupChatMessageReturnQuantity { get; set; }
        public Routes Routes { get; set; }
    }

    public class Routes
    {
        public string GetAllGroupChat { get; set; }
        public string GetLastGroupChatMessage { get; set; }
        public string SendMessageToGroup { get; set; }
        public string CreateGroupChat { get; set; }
    }
}