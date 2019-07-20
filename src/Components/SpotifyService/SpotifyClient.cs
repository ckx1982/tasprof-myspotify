using Tasprof.Components.SpotifyClient.Services.Spotify;

namespace Tasprof.Components.SpotifyClient
{
    public class SpotifyClient : ISpotifyClient
    {
        private readonly IGlobalSettings _globalSettings;
        public ISpotifyService SpotifyService { get; }

        public SpotifyClient(IGlobalSettings globalSettings, ISpotifyService spotifyService)
        {
            _globalSettings = globalSettings;
            SpotifyService = spotifyService;
        }
    }
}
