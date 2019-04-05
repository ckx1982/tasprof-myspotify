using Tasprof.Components.SpotifyClient.Services.Spotify;

namespace Tasprof.Components.SpotifyClient
{
    public interface ISpotifyClient
    {
        ISpotifyService SpotifyService { get; }
    }
}
