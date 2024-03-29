﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Tasprof.Apps.MySpotify.Core.Constants;
using Tasprof.Apps.MySpotify.Core.Models;
using Tasprof.Apps.MySpotify.Core.Services.Request;

namespace Tasprof.Apps.MySpotify.Core.Services.Spotify
{
    public class SpotifyService :ISpotifyService
    {
        private readonly IRequestService _requestService;

        public SpotifyService(IRequestService requestService)
        {
            _requestService = requestService;  
        }

        public async Task<List<Playlist>> GetPlaylists()
        {
            var uri = $"{SpotifyWebApi.SpotifyApiUri}me/playlists?limit=50";
            var result = await _requestService.GetAsync<Playlists>(uri);
            return result.Items;
        }

        public async Task<List<PlaylistItem>> GetPlaylistItems(string playlistId)
        {
            var uri = $"{SpotifyWebApi.SpotifyApiUri}playlists/{playlistId}/tracks";
            var result = await _requestService.GetAsync<PlaylistItems>(uri);
            return result.Items;

        }

        public async Task<List<Artist>> GetTopArtists()
        {
            var uri = $"{SpotifyWebApi.SpotifyApiUri}me/top/artists?limit=10&offset=0";
            var result = await _requestService.GetAsync<Artists>(uri);
            return result.Items;
        }

        public async Task<List<Track>> GetTopTracks()
        {
            var uri = $"{SpotifyWebApi.SpotifyApiUri}me/top/tracks?limit=50";
            var result = await _requestService.GetAsync<Tracks>(uri);
            return result.Items;
        }

        public async Task<PlayHistoryItems> GetRecentlyPlayedTracks(long before, int limit)
        {
            var uri = $"{SpotifyWebApi.SpotifyApiUri}me/player/recently-played?before={before}&limit={limit}";
            //var uri = $"{GlobalSettings.Instance.BaseGeneralSpotifyUri}me/player/recently-played?limit={limit}";

            var result = await _requestService.GetAsync<PlayHistoryItems>(uri);
            return result;
        }

    }
}
