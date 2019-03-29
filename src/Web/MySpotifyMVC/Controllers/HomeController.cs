using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySpotifyMVC.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
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

        //[Authorize]
        public async Task<IActionResult> Index()
        {
            var playllists = await _spotifyService.GetPlaylists();
            return View(playllists);
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
