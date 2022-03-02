﻿using Bogus;

namespace NetCoreChatRoom.Models.NetCoreChatRoomAPIService.GroupChat
{
    public class ListGroupChatModel
    {
        public List<GroupChatModel> GroupChat;

        public void AutoGenerateData(int HowManyData)
        {
            GroupChat = new List<GroupChatModel>();
            var faker = new Faker<GroupChatModel>().StrictMode(true)
                .RuleFor(p => p.Id, f => f.IndexFaker)
                .RuleFor(p => p.Name, f => f.Name.JobTitle())
                .RuleFor(p => p.Description, f => f.Name.JobDescriptor())
                .RuleFor(p => p.LastReceivedMessage, f => f.Date.ToString());

            GroupChat = faker.Generate(HowManyData);
        }
    }

    public class GroupChatModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LastReceivedMessage { get; set; }
    }
}