using System.Collections.Generic;
using System.Threading.Tasks;
using Tasprof.Components.SpotifyClient.Models;

namespace Tasprof.Components.SpotifyClient.Services.Spotify
{
    public interface ISpotifyService
    {
        Task<List<Playlist>> GetPlaylists();
        Task<List<PlaylistItem>> GetPlaylistItems(string playlistId);
        Task<List<Artist>> GetTopArtists();
        Task<List<Track>> GetTopTracks();
        Task<PlayHistoryItems> GetRecentlyPlayedTracks(long before, int limit);
    }
}
