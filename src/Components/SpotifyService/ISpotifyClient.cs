using Tasprof.Components.SpotifyClient.Services.Spotify;
using Tasprof.Components.SpotifyClient.Services.SpotifyChart;

namespace Tasprof.Components.SpotifyClient
{
    public interface ISpotifyClient
    {
        ISpotifyService SpotifyService { get; }
        ISpotifyChartService SpotifyChartService { get; }
    }
}
