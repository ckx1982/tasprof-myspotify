using System.Collections.Generic;
using System.Threading.Tasks;
using Tasprof.Apps.MySpotify.Core.Models;
using Tasprof.Apps.MySpotify.Core.Services.Spotify;

namespace Tasprof.Apps.MySpotify.Core.ViewModels.Toplists
{
    public class TracksViewModel: BaseViewModel
    {
        private ISpotifyService _spotifyService;
        private List<Track> _tracks;
        public List<Track> Tracks
        {
            get { return _tracks; }
            set { SetProperty(ref _tracks, value); }
        }

        public TracksViewModel(ISpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
        }

        public async override Task Initialize()
        {
            await base.Initialize();
            Tracks = await _spotifyService.GetTopTracks();
        }

    }
}
