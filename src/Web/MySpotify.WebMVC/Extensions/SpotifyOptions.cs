using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Tasprof.Apps.MySpotify.WebMvc.Extensions
{
    public class SpotifyOptions: OAuthOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpotifyOptions"/> class.
        /// </summary>
        public SpotifyOptions()
        {
            //this.CallbackPath = new PathString("/signin-spotify");
            this.CallbackPath = new PathString("/signin");
            this.AuthorizationEndpoint = SpotifyDefaults.AuthorizationEndpoint;
            this.TokenEndpoint = SpotifyDefaults.TokenEndpoint;
            this.UserInformationEndpoint = SpotifyDefaults.UserInformationEndpoint;
            this.Scope.Add(SpotifyDefaults.UserReadEmailScope);
            this.Scope.Add(SpotifyDefaults.UserReadRecentlyPlayedScope);

            //ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
            //ClaimActions.MapCustomJson(ClaimTypes.Name, SpotifyHelper.GetName);
            //ClaimActions.MapJsonKey(ClaimTypes.Email, "email");
            //ClaimActions.MapCustomJson(SpotifyClaimTypes.ProfilePicture, SpotifyHelper.GetProfilePicture);
        }

    }
}
