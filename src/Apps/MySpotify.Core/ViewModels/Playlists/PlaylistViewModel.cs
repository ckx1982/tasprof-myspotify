using System.Collections.Generic;
using System.Threading.Tasks;
using Tasprof.Apps.MySpotify.Core.Models;
using Tasprof.Apps.MySpotify.Core.Navigation;
using Tasprof.Apps.MySpotify.Core.Services.Spotify;

namespace Tasprof.Apps.MySpotify.Core.ViewModels.Playlists
{

    public class PlaylistViewModel : BaseViewModelParam<PlaylistNavigationArgs>
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
