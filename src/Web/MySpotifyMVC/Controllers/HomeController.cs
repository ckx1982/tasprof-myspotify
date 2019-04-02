using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySpotifyMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Tasprof.Apps.MySpotifyDroid;
using Tasprof.Apps.MySpotifyDroid.Exceptions;
using Tasprof.Apps.MySpotifyDroid.Models;
using Tasprof.Apps.MySpotifyDroid.Services.Spotify;

namespace MySpotifyMVC.Controllers
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
