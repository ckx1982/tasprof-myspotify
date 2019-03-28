using MvvmCross.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tasprof.Apps.MySpotifyDroid.Models;
using Tasprof.Apps.MySpotifyDroid.Services.Spotify;

namespace Tasprof.Apps.MySpotifyDroid.ViewModels
{
    public class TracksViewModel: MvxViewModel
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
