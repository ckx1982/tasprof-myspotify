using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tasprof.Apps.MySpotify.WebMvc.ViewModels.Charts;
using Tasprof.Components.SpotifyClient;

namespace Tasprof.Apps.MySpotify.WebMvc.Controllers.Charts
{
    public class ChartsController : Controller
    {
        private readonly ISpotifyClient _spotifyClient;

        public ChartsController(ISpotifyClient spotifyClient)
        {
            _spotifyClient = spotifyClient;
        }

        [Authorize]
        public async Task<IActionResult> Create(string id)
        {
            var spotifyChart = await _spotifyClient.SpotifyChartService.CreateChart(id);
            return View(new CreateChartViewModel{ Chart = spotifyChart });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateChartViewModel createChartViewModel)
        {
            if (ModelState.IsValid)
            {
                await _spotifyClient.SpotifyChartService.CreateChart("");
                RedirectToRoute("Playlists");
            }
            return View(createChartViewModel);
        }
    }
}
