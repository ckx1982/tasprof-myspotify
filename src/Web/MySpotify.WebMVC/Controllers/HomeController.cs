using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasprof.Apps.MySpotify.WebMvc.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Tasprof.Components.SpotifyClient;

namespace Tasprof.Apps.MySpotify.WebMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISpotifyClient _spotifyClient;

        public HomeController(ISpotifyClient spotifyClient)
        {
            _spotifyClient = spotifyClient;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
                var playHistoryItems = await _spotifyClient.SpotifyService.GetRecentlyPlayedTracks(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(), 15);
                return View(playHistoryItems);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[Authorize]
        //public async Task<IActionResult> Chart(string id)
        //{
        //    var spotifyChart = await _spotifyClient.SpotifyChartService.CreateChart(id);
        //    return View(spotifyChart);
        //}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
