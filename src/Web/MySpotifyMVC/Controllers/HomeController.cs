using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySpotifyMVC.Models;
using Tasprof.Apps.MySpotifyDroid;
using Tasprof.Apps.MySpotifyDroid.Services.Identity;
using Tasprof.Apps.MySpotifyDroid.Services.Spotify;

namespace MySpotifyMVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly ISpotifyService _spotifyService;
        private readonly IIdentityService _identityService;

        public HomeController(ISpotifyService spotifyService, IIdentityService identityService)
        {
            _spotifyService = spotifyService;
            _identityService = identityService;
        }

        public IActionResult Index()
        {
            var request = _identityService.CreateAuthorizationRequest();
           
            return Redirect(request);
        }

        public async Task<IActionResult> Privacy()
        {
            var playllists = await _spotifyService.GetTopArtists();
            return View();
        }

        public async Task<IActionResult> AuthResponse(string code)
        {
            GlobalSettings.Instance.AuthCode = code;
            var token = await _identityService.GetTokenAsync(code);
            GlobalSettings.Instance.AuthToken = token.AccessToken;
            return RedirectToAction("Privacy");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
