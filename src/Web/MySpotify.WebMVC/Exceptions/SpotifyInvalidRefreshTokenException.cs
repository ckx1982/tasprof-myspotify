using System;
namespace Tasprof.Apps.MySpotify.WebMvc.Exceptions
{
    public class SpotifyInvalidRefreshTokenException : SpotifyServiceException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpotifyInvalidRefreshTokenException"/> class.
        /// </summary>
        /// <param name="innerException">The inner exception.</param>
        public SpotifyInvalidRefreshTokenException(Exception innerException) : base("Invalid refresh token exception has occurred.", innerException)
        {
        }
    }
}
