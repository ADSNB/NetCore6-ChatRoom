using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCoreChatRoom.Components.GroupChat;
using NetCoreChatRoom.Components.GroupChatMessage;
using NetCoreChatRoom.Models.NetCoreChatRoomAPIService.GroupChat;
using NetCoreChatRoom.Models.NetCoreChatRoomAPIService.GroupChatMessage;
using NetCoreChatRoom.Services.Interfaces;
using Newtonsoft.Json;
using Serilog;

namespace NetCoreChatRoom.Controllers
{
    [AllowAnonymous]
    public class ChatRoomController : Controller
    {
        private readonly INetCoreChatRoomAPIService _netCoreChatRoomAPIService;

        public ChatRoomController(INetCoreChatRoomAPIService netCoreChatRoomAPIService) => _netCoreChatRoomAPIService = netCoreChatRoomAPIService;

        public IActionResult Index() => View();

        [HttpPost]
        public async Task<IActionResult> SendMessage()
        {
            try
            {
                await _netCoreChatRoomAPIService.SendMessage("Alan", "Teste");

                return Ok("ok");
            }
            catch (Exception ex)
            {
                Log.Error(JsonConvert.SerializeObject(ex));
                throw;
            }
        }

        [HttpGet]
        public IActionResult GetChatGroups(int codGroupChat)
        {
            try
            {
                return ViewComponent(typeof(GroupChatViewComponent));
            }
            catch (Exception ex)
            {
                Log.Error(JsonConvert.SerializeObject(ex));
                throw;
            }
        }

        [HttpGet]
        public IActionResult GetChatMessagesFromGroup(int codGroupChat)
        {
            try
            {
                return ViewComponent(typeof(GroupChatMessageViewComponent), codGroupChat);
            }
            catch (Exception ex)
            {
                Log.Error(JsonConvert.SerializeObject(ex));
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> SendMessageToGroup(string connectionId, int codGroupChat, string message)
        {
            try
            {
                var model = new SendMessageToGroupModel(connectionId, codGroupChat, User.Claims.Where(c => c.Type.Equals("name")).FirstOrDefault().Value, message);
                await _netCoreChatRoomAPIService.SendMessageToGroup(model);
                return Ok("ok");
            }
            catch (Exception ex)
            {
                Log.Error(JsonConvert.SerializeObject(ex));
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroupChat(string connectionId, string groupName, string groupDescription)
        {
            try
            {
                var inputModel = new CreateGroupChatModel(connectionId, groupName, groupDescription, User.Claims.Where(c => c.Type.Equals("name")).FirstOrDefault().Value);
                await _netCoreChatRoomAPIService.CreateGroupChat(inputModel);

                return Ok("ok");
            }
            catch (Exception ex)
            {
                Log.Error(JsonConvert.SerializeObject(ex));
                throw;
            }
        }
    }
}