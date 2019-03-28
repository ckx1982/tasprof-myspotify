using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySpotifyMVC.Models;
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
        public async Task<IActionResult> Index()
        {
            var playllists = await _spotifyService.GetPlaylists();
            return View();
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
