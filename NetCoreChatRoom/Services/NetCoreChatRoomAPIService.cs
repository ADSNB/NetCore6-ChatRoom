using NetCoreChatRoom.Models;
using NetCoreChatRoom.Models.NetCoreChatRoomAPIService.GroupChat;
using NetCoreChatRoom.Models.NetCoreChatRoomAPIService.GroupChatMessage;
using NetCoreChatRoom.Services.Interfaces;
using RestSharp;

namespace NetCoreChatRoom.Services
{
    public class NetCoreChatRoomAPIService : INetCoreChatRoomAPIService
    {
        private readonly AppSettingsModel _appSettings;
        private readonly RestClient _client;

        public NetCoreChatRoomAPIService(AppSettingsModel appSettings, IHttpContextAccessor httpContextAccessor)
        {
            _appSettings = appSettings;

            #region Authentication API not finished

            /* Authentication API
            var cookieContainer = new CookieContainer();
            var netCoreCookie = httpContextAccessor.HttpContext.Request.Cookies.ContainsKey(".AspNetCore.Cookies") ? httpContextAccessor.HttpContext.Request.Cookies.FirstOrDefault(c => c.Key.Equals(".AspNetCore.Cookies")) : new KeyValuePair<string, string>();

            if (!netCoreCookie.Equals(new KeyValuePair<string, string>()))
                cookieContainer.Add(new Uri(_appSettings.WebSiteDomain), new Cookie(netCoreCookie.Key, netCoreCookie.Value));
            else
            {
                foreach (var cookie in httpContextAccessor.HttpContext.Request.Cookies)
                    cookieContainer.Add(new Uri(_appSettings.WebSiteDomain), new Cookie(cookie.Key, cookie.Value));
            }
            */

            #endregion Authentication API not finished

            var options = new RestClientOptions(_appSettings.NetCoreChatRoomAPI.BaseUrl)
            {
                ThrowOnAnyError = true,
                Timeout = _appSettings.NetCoreChatRoomAPI.ServiceTimeoutInMiliseconds,
                //CookieContainer = cookieContainer,
            };
            _client = new RestClient(options);
        }

        public async Task<object?> Get()
        {
            try
            {
                var request = new RestRequest("WeatherForecast", Method.Get);
                //.AddQueryParameter("foo", "bar")
                //.AddJsonBody(someObject);

                var response = await _client.GetAsync<object>(request);
                return response;
            }
            catch (Exception ex)
            {
                var exa = ex;
                return null;
            }
        }

        public async Task<object?> SendMessage(string user, string message)
        {
            try
            {
                var request = new RestRequest("Chat", Method.Post);
                request.AddQueryParameter("user", user);
                request.AddQueryParameter("message", message);

                var response = await _client.PostAsync<object>(request);
                return response;
            }
            catch (Exception ex)
            {
                var exa = ex;
                return null;
            }
        }

        public async Task<object> GetAllGroupChat()
        {
            try
            {
                var request = new RestRequest(_appSettings.NetCoreChatRoomAPI.Routes.GetAllGroupChat, Method.Get);
                var response = await _client.GetAsync<List<GroupChatModel>>(request);
                var model = new ListGroupChatModel();
                model.GroupChat = response;
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<object> GetLastGroupChatMessage(GetLastGroupChatMessageModel inputModel)
        {
            try
            {
                var request = new RestRequest(_appSettings.NetCoreChatRoomAPI.Routes.GetLastGroupChatMessage, Method.Get);
                request.AddBody(inputModel);
                var response = await _client.GetAsync<List<GroupChatMessageModel>>(request);
                var model = new ListGroupChatMessageModel();
                model.GroupChatMessage = response;
                model.CodGroupChat = inputModel.CodGroupChat;
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<object> CreateGroupChat(CreateGroupChatModel model)
        {
            try
            {
                var request = new RestRequest(_appSettings.NetCoreChatRoomAPI.Routes.CreateGroupChat, Method.Post);
                request.AddBody(model);
                var response = await _client.PostAsync(request);
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<object> SendMessageToGroup(SendMessageToGroupModel model)
        {
            try
            {
                var request = new RestRequest(_appSettings.NetCoreChatRoomAPI.Routes.SendMessageToGroup, Method.Post);
                request.AddBody(model);
                var response = await _client.PostAsync(request);
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}