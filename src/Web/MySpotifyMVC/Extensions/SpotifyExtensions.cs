using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MySpotifyMVC.Extensions
{
    public static class SpotifyExtensions
    {
        /// <summary>
        /// Adds the Spotify authentication to <see cref="AuthenticationBuilder"/>.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="authenticationScheme">The authentication scheme.</param>
        /// <param name="configureOptions">The configure options.</param>
        /// <returns></returns>
        public static AuthenticationBuilder AddSpotify(this AuthenticationBuilder builder, string authenticationScheme, Action<SpotifyOptions> configureOptions)
            => builder.AddSpotify(authenticationScheme, SpotifyDefaults.DisplayName, configureOptions);


        /// <summary>
        /// Adds the Spotify authentication to <see cref="AuthenticationBuilder"/>.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="authenticationScheme">The authentication scheme.</param>
        /// <param name="displayName">The display name.</param>
        /// <param name="configureOptions">The configure options.</param>
        /// <returns></returns>
        public static AuthenticationBuilder AddSpotify(this AuthenticationBuilder builder, string authenticationScheme, string displayName, Action<SpotifyOptions> configureOptions)
            => builder.AddOAuth<SpotifyOptions, SpotifyHandler>(authenticationScheme, displayName, configureOptions);
    }
}
