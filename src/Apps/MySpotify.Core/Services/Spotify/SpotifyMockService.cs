using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tasprof.Apps.MySpotify.Core.Models;
using Tasprof.Apps.MySpotify.Core.Services.Request;

namespace Tasprof.Apps.MySpotify.Core.Services.Spotify
{
    public class SpotifyMockService : ISpotifyService
    {

        public async Task<List<Playlist>> GetPlaylists()
        {
            var playlists = new List<Playlist>();

            playlists.Add(
                new Playlist
                {
                    Id = "1",
                    Name = "Playlist 1"
                }
            );

            playlists.Add(new Playlist
            {
                Id = "2",
                Name = "Playlist 2"
            }
            );

            await Task.Delay(1);
            return playlists;
        }

        public async Task<List<PlaylistItem>> GetPlaylistItems(string playlistId)
        {
            await Task.Delay(1);
            throw new NotImplementedException();
        }

        public async Task<List<Artist>> GetTopArtists()
        {

            await Task.Delay(1);
            throw new NotImplementedException();
        }

        public async Task<List<Track>> GetTopTracks()
        {

            await Task.Delay(1);
            throw new NotImplementedException();
        }

        public async Task<PlayHistoryItems> GetRecentlyPlayedTracks(long before, int limit)
        {
            await Task.Delay(1);
            throw new NotImplementedException();
        }

    }
}
