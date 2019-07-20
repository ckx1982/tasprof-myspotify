using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tasprof.Apps.MySpotify.WebMvc.ViewModels.Playlists;
using Tasprof.Components.SpotifyClient;

namespace Tasprof.Apps.MySpotify.WebMvc.Controllers.Playlists
{
    public class PlaylistsController : Controller
    { 
        private readonly ISpotifyClient _spotifyClient;

        public PlaylistsController(ISpotifyClient spotifyClient)
        {
            _spotifyClient = spotifyClient;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var playlists = await _spotifyClient.SpotifyService.GetPlaylists();
            var playlistViewModels = new List<PlaylistViewModel>();
            foreach (var playlist in playlists)
            {
                playlistViewModels.Add(new PlaylistViewModel
                {
                    Id = playlist.Id,
                    Name = playlist.Name,
                    ImageUrl = playlist.MainImage.Url

                });
            }
            return View(playlistViewModels);
        }
    }
}
