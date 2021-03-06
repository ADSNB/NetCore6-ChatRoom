using Microsoft.AspNetCore.Mvc;
using NetCoreChatRoom.Services.Interfaces;
using Newtonsoft.Json;
using Serilog;

namespace NetCoreChatRoom.Components.GroupChat
{
    public class GroupChatViewComponent : ViewComponent
    {
        private readonly INetCoreChatRoomAPIService _netCoreChatRoomAPIService;

        public GroupChatViewComponent(INetCoreChatRoomAPIService netCoreChatRoomAPIService) => _netCoreChatRoomAPIService = netCoreChatRoomAPIService;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var model = await _netCoreChatRoomAPIService.GetAllGroupChat();

                #region test pourposes

                //var model = new ListGroupChatModel();
                //model.AutoGenerateData(2);

                #endregion test pourposes

                return View(model);
            }
            catch (Exception ex)
            {
                Log.Error(JsonConvert.SerializeObject(ex));
                throw;
            }
        }
    }
}