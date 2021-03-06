using AutoFixture;

namespace NetCoreChatRoom.Models.NetCoreChatRoomAPIService.GroupChatMessage
{
    public class ListGroupChatMessageModel
    {
        public int CodGroupChat { get; set; }
        public List<GroupChatMessageModel> GroupChatMessage { get; set; }

        public void AutoGenerateData(int HowManyData)
        {
            Fixture fixture = new Fixture();
            var fakeData = fixture.CreateMany<GroupChatMessageModel>(HowManyData);
            GroupChatMessage = fakeData.ToList();
        }
    }

    public class GroupChatMessageModel
    {
        public int Id { get; set; }
        public int CodGroupChat { get; set; }
        public string FromUser { get; set; }
        public string Message { get; set; }
    }
}