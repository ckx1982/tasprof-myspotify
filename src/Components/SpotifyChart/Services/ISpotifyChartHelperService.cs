using System.Collections.Generic;
using Tasprof.Components.SpotifyModels;

namespace Tasprof.Components.SpotifyChart.Services
{
    public interface ISpotifyChartHelperService
    {
        Models.SpotifyChart ConvertSpotifyPlaylistItemsToSpotifyChart(PlaylistItems playlistItems);

        Models.SpotifyChart ConvertSpotifyPlaylistItemsToSpotifyChart(IList<PlaylistItem> playlistItems);
    }
}
