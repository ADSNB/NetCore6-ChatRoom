using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCoreChatRoom.Components.GroupChat;
using NetCoreChatRoom.Components.GroupChatMessage;
using NetCoreChatRoom.Models.NetCoreChatRoomAPIService.GroupChat;
using NetCoreChatRoom.Models.NetCoreChatRoomAPIService.GroupChatMessage;
using NetCoreChatRoom.Services.Interfaces;

namespace NetCoreChatRoom.Controllers
{
    [AllowAnonymous]
    public class ChatRoomController : Controller
    {
        private readonly INetCoreChatRoomAPIService _netCoreChatRoomAPIService;

        public ChatRoomController(INetCoreChatRoomAPIService netCoreChatRoomAPIService) => _netCoreChatRoomAPIService = netCoreChatRoomAPIService;

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage()
        {
            await _netCoreChatRoomAPIService.SendMessage("Alan", "Teste");

            return Ok("ok");
        }

        [HttpGet]
        public IActionResult GetChatGroups(int codGroupChat)
        {
            return ViewComponent(typeof(GroupChatViewComponent));
        }

        [HttpGet]
        public IActionResult GetChatMessagesFromGroup(int codGroupChat)
        {
            return ViewComponent(typeof(GroupChatMessageViewComponent), codGroupChat);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessageToGroup(string connectionId, int codGroupChat, string message)
        {
            var model = new SendMessageToGroupModel(connectionId, codGroupChat, User.Claims.Where(c => c.Type.Equals("name")).FirstOrDefault().Value, message);
            await _netCoreChatRoomAPIService.SendMessageToGroup(model);
            return Ok("ok");
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroupChat(string connectionId, string groupName, string groupDescription)
        {
            var inputModel = new CreateGroupChatModel(connectionId, groupName, groupDescription, User.Claims.Where(c => c.Type.Equals("name")).FirstOrDefault().Value);
            await _netCoreChatRoomAPIService.CreateGroupChat(inputModel);

            return Ok("ok");
        }
    }
}