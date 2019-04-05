using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasprof.Apps.MySpotify.WebMvc.Extensions
{
    /// <summary>
    /// Default values for Spotify authentication.
    /// </summary>
    public static class SpotifyDefaults
    {
        /// <summary>
        /// The authentication scheme.
        /// </summary>
        public const string AuthenticationScheme = "Spotify";

        /// <summary>
        /// The display name.
        /// </summary>
        public const string DisplayName = "Spotify";

        /// <summary>
        /// The user read email scope.
        /// </summary>
        public const string UserReadEmailScope = "user-read-email";

        /// <summary>
        /// The URL for getting authorization from the Spotify Accounts Service.
        /// </summary>
        public static readonly string AuthorizationEndpoint = "https://accounts.spotify.com/authorize";
        //public static readonly string AuthorizationEndpoint = "http://google.de";

        /// <summary>
        /// The URL for getting OAuth tokens from Spotify Accounts Service.
        /// </summary>
        public static readonly string TokenEndpoint = "https://accounts.spotify.com/api/token";

        /// <summary>
        /// The URL for getting info about current user.
        /// </summary>
        public static readonly string UserInformationEndpoint = "https://api.spotify.com/v1/me";

        public static string UserReadRecentlyPlayedScope = "user-read-recently-played";
    }
}
