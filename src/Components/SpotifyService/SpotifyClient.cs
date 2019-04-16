using Tasprof.Components.SpotifyClient.Services.Spotify;
using Tasprof.Components.SpotifyClient.Services.SpotifyChart;

namespace Tasprof.Components.SpotifyClient
{
    public class SpotifyClient : ISpotifyClient
    {
        private readonly IGlobalSettings _globalSettings;
        public ISpotifyService SpotifyService { get; }
        public ISpotifyChartService SpotifyChartService { get;  }

        public SpotifyClient(IGlobalSettings globalSettings, ISpotifyService spotifyService, ISpotifyChartService spotifyChartService)
        {
            _globalSettings = globalSettings;
            SpotifyService = spotifyService;
            SpotifyChartService = spotifyChartService;

        }
    }
}
