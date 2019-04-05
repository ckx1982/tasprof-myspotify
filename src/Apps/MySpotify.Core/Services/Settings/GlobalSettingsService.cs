using Tasprof.Apps.MySpotify.Core.Helpers;

namespace Tasprof.Apps.MySpotify.Core
{
    public class GlobalSettingsService : IGlobalSettingsService
    {
        //private static readonly GlobalSettings _instance = new GlobalSettings();

        //public string ClientId = Secrets.ClientId; 
        //public string ClientSecret = Secrets.ClientSecret; 
        //public string RedirectUri = "https://localhost:5001/Home/AuthResponse";
        //public string BaseGeneralSpotifyUri = "https://api.spotify.com/v1/";

        //public string AuthorizeUri = "https://accounts.spotify.com/de/authorize";
        ////public string AuthorizeLoginUri = "https://accounts.spotify.com/de/login";
        ////public string AuthorizeFacebookUri = "https://www.facebook.com/v2.3/dialog/oauth";
        ////public string AuthorizeFacebookSpotifyUri = "https://accounts.spotify.com/api/facebook/oauth/";

        ////public string AuthorizeUri = "https://accounts.spotify.com/de/login?continue=https%3A%2F%2Faccounts.spotify.com%2Fde%2Fauthorize%3F";
        //public string TokenUri = "https://accounts.spotify.com/api/token";
        //public string TopDataUri = "https://api.spotify.com/v1/me/top/";


        //public GlobalSettings()
        //{
         
        //}

        //public static GlobalSettings Instance
        //{
        //    get { return _instance; }
        //}

        string IGlobalSettingsService.RefreshToken { get; set; }

        string IGlobalSettingsService.AccessToken { get; set; }

        string IGlobalSettingsService.AuthorizationCode { get; set; }

        string IGlobalSettingsService.ClientId => Secrets.ClientId;

        string IGlobalSettingsService.ClientSecret => Secrets.ClientSecret;

        string IGlobalSettingsService.RedirectUri { get; set; }


    }
}
