namespace Tasprof.Components.SpotifyClient
{
    public interface IGlobalSettings
    {
        string ClientId { get; }
        string ClientSecret { get; }
        string RedirectUri { get; }

        string AuthCode { get; set; }
        string AuthToken { get; set; }
        string RefreshToken { get; set; }
    }
}