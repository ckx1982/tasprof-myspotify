using System.Collections.Generic;
using System.Threading.Tasks;
using Tasprof.Apps.MySpotifyDroid.Models;
using Tasprof.Apps.MySpotifyDroid.Services.Request;
using Tasprof.Apps.MySpotifyDroid.Services.Token;

namespace Tasprof.Apps.MySpotifyDroid.Services.Spotify
{
    public class SpotifyService :ISpotifyService
    {
        private readonly IRequestService _requestService;
        private readonly ITokenService _tokenService;

        public SpotifyService(IRequestService requestService, ITokenService tokenService)
        {
            _requestService = requestService;  
            _tokenService = tokenService;
        }

        public async Task<List<Playlist>> GetPlaylists()
        {
            var uri = $"{GlobalSettings.Instance.BaseGeneralSpotifyUri}me/playlists?limit=50";
            var token = await _tokenService.GetTokenAsync();
            var result = await _requestService.GetAsync<Playlists>(uri, token);
            return result.Items;
        }

        public async Task<List<PlaylistItem>> GetPlaylistItems(string playlistId)
        {
            var uri = $"{GlobalSettings.Instance.BaseGeneralSpotifyUri}playlists/{playlistId}/tracks";
            var result = await _requestService.GetAsync<PlaylistItems>(uri, GlobalSettings.Instance.AuthToken);
            return result.Items;

        }

        public async Task<List<Artist>> GetTopArtists()
        {
            var uri = $"{GlobalSettings.Instance.BaseGeneralSpotifyUri}me/top/artists?limit=10&offset=0";
            var result = await _requestService.GetAsync<Artists>(uri, GlobalSettings.Instance.AuthToken);
            return result.Items;
        }

        public async Task<List<Track>> GetTopTracks()
        {
            var uri = $"{GlobalSettings.Instance.BaseGeneralSpotifyUri}me/top/tracks?limit=50";
            var result = await _requestService.GetAsync<Tracks>(uri, GlobalSettings.Instance.AuthToken);
            return result.Items;
        }

        public async Task<PlayHistoryItems> GetRecentlyPlayedTracks(long before, int limit)
        {
            var uri = $"{GlobalSettings.Instance.BaseGeneralSpotifyUri}me/player/recently-played?before={before}&limit={limit}";
            //var uri = $"{GlobalSettings.Instance.BaseGeneralSpotifyUri}me/player/recently-played?limit={limit}";

            var result = await _requestService.GetAsync<PlayHistoryItems>(uri, GlobalSettings.Instance.AuthToken);
            return result;
        }

    }
}
