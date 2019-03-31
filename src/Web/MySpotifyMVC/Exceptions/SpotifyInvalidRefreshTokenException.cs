using System;
namespace MySpotifyMVC.Exceptions
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
