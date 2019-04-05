using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Tasprof.Apps.MySpotify.WebMvc.Exceptions;
using System;

namespace Tasprof.Apps.MySpotify.WebMvc.Extensions
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


        /// <summary>
        /// Handles the spotify invalid refresh token exception.
        /// </summary>
        /// <param name="applicationBuilder">The application builder.</param>
        /// <param name="loginPath">The login path.</param>
        /// <param name="authenticationScheme">The authentication scheme.</param>
        /// <returns></returns>
        public static IApplicationBuilder UseSpotifyInvalidRefreshTokenExceptionHandler(this IApplicationBuilder applicationBuilder, string loginPath, string authenticationScheme = null)
        {
            return applicationBuilder.Use(async (context, next) =>
            {
                try
                {
                    await next.Invoke();
                }
                catch (SpotifyInvalidRefreshTokenException)
                {
                    await context.SignOutAsync(authenticationScheme).ConfigureAwait(false);
                    context.Response.Redirect(loginPath);
                }

            });
        }
    }
}
