using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCoreChatRoom.Models;
using NetCoreChatRoom.Services.Interfaces;
using System.Diagnostics;

namespace NetCoreChatRoom.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INetCoreChatRoomAPIService _chatRoomService;

        public HomeController(ILogger<HomeController> logger, INetCoreChatRoomAPIService netCoreChatRoomAPIService)
        {
            _logger = logger;
            _chatRoomService = netCoreChatRoomAPIService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            // var novo = await _chatRoomService.Get();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}