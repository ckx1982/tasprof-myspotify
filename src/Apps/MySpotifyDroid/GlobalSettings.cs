using System;
using System.Collections.Generic;
using System.Text;
using Tasprof.Apps.MySpotifyDroid.Helpers;

namespace Tasprof.Apps.MySpotifyDroid
{
    public class GlobalSettings
    {
        private static readonly GlobalSettings _instance = new GlobalSettings();

        public string ClientId = Secrets.ClientId; 
        public string ClientSecret = Secrets.ClientSecret; 
        public string RedirectUri = "myspotify://customtabs";
        public string BaseGeneralSpotifyUri = "https://api.spotify.com/v1/";

        public GlobalSettings()
        {
         
        }

        public static GlobalSettings Instance
        {
            get { return _instance; }
        }

        public string AuthToken { get; set; }
        public string AuthCode { get; set; }
    }
}
