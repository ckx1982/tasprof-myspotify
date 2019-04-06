using Tasprof.Components.SpotifyClient.Helpers;

namespace Tasprof.Components.SpotifyClient
{
    public class GlobalSettings : IGlobalSettings
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

        public string RefreshToken { get; set; }
        public string AuthToken { get; set; }
        public string AuthCode { get; set; }

        //string IGlobalSettings.AuthorizeUri => "https://accounts.spotify.com/de/authorize";

        string IGlobalSettings.ClientId => Secrets.ClientId;

        string IGlobalSettings.ClientSecret => Secrets.ClientSecret;

        string IGlobalSettings.RedirectUri => "https://localhost:5001/signin";

        //string IGlobalSettings.BaseGeneralSpotifyUri => "https://api.spotify.com/v1/";

        //string IGlobalSettings.TokenUri => "https://accounts.spotify.com/api/token";

        //string IGlobalSettings.TopDataUri => "https://api.spotify.com/v1/me/top/";
    }
}
