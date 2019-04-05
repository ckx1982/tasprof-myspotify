using System.Collections.Generic;
using System.Threading.Tasks;
using Tasprof.Apps.MySpotify.Core.Models;
using Tasprof.Apps.MySpotify.Core.Services.Spotify;

namespace Tasprof.Apps.MySpotify.Core.ViewModels.Toplists
{
    public class ArtistsViewModel : BaseViewModel
    {
        private readonly ISpotifyService _spotifyService;

        private List<Artist> _artists;
        public List<Artist> Artists
        {
            get { return _artists; }
            set { SetProperty(ref _artists, value); }
        }

        public ArtistsViewModel(ISpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
        }

        public async override Task Initialize()
        {
            await base.Initialize();
            Artists = await _spotifyService.GetTopArtists();
        }

    }
}
