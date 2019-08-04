using Tasprof.Components.SpotifyModels;

namespace Tasprof.Components.SpotifyChart.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISpotifyChartWriterService
    {
        void WritePlaylistToSpotifyChart(PlaylistItems playlistItems);
    }
}
