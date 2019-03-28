using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.ViewModels;
using Tasprof.Apps.MySpotifyDroid.Models;
using Tasprof.Apps.MySpotifyDroid.Navigation;
using Tasprof.Apps.MySpotifyDroid.Services.Spotify;

namespace Tasprof.Apps.MySpotifyDroid.ViewModels
{

    public class PlaylistViewModel : MvxViewModel<PlaylistNavigationArgs>
    {
        private readonly ISpotifyService _spotifyService;

        private string playlistId;

        private List<PlaylistItem> _playlistItems;
        public List<PlaylistItem> PlaylistItems { get { return _playlistItems; } set { SetProperty(ref _playlistItems, value); } }

        public PlaylistViewModel(ISpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
        }

        public override void Prepare(PlaylistNavigationArgs parameter)
        {
            playlistId = parameter.PlaylistId;
        }

        public override async Task Initialize()
        {
            await base.Initialize();
            //var uri = $"{GlobalSettings.Instance.BaseGeneralSpotifyUri}playlists/{playlistId}/tracks";
            //var result = await requestService.GetAsync<PlaylistItems>(uri, GlobalSettings.Instance.AuthToken);
            PlaylistItems = await _spotifyService.GetPlaylistItems(playlistId);
        }
    }
}
