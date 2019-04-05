namespace Tasprof.Apps.MySpotify.Core
{
    public interface IGlobalSettingsService
    {
        string ClientId { get;  }
        string ClientSecret { get; }
        string RedirectUri { get; set; }
   
        string AuthorizationCode { get; set; }
        string AccessToken { get; set; }
        string RefreshToken { get; set; }
    }
}