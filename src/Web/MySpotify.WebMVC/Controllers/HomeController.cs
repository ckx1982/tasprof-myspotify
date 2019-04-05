using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasprof.Apps.MySpotify.WebMvc.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Tasprof.Apps.MySpotify.Core.Services.Spotify;

namespace Tasprof.Apps.MySpotify.WebMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISpotifyService _spotifyService;

        public HomeController(ISpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
                //GlobalSettings.Instance.AuthToken = await HttpContext.GetTokenAsync("access_token");
                var playHistoryItems = await _spotifyService.GetRecentlyPlayedTracks(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(), 15);
                return View(playHistoryItems);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
