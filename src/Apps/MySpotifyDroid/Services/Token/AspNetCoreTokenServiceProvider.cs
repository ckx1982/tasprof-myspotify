using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Tasprof.Apps.MySpotifyDroid.Models;
using Tasprof.Apps.MySpotifyDroid.Services.Request;

namespace Tasprof.Apps.MySpotifyDroid.Services.Token
{
    public class AspNetCoreTokenServiceProvider : ITokenService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AspNetCoreTokenServiceProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> GetAccessTokenAsync()
        {
            if (string.IsNullOrEmpty(GlobalSettings.Instance.AuthToken))
            {
                GlobalSettings.Instance.AuthToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");
            }
            return GlobalSettings.Instance.AuthToken;
        }

        public async Task<string> GetNewAccessTokenAsync(IRequestService requestService)
        {
            GlobalSettings.Instance.AuthToken = string.Empty;
            var refresh_token = await _httpContextAccessor.HttpContext.GetTokenAsync("refresh_token");
            var userToken = await requestService.PostAsync<UserToken>(GlobalSettings.Instance.TokenUri, $"grant_type=refresh_token&refresh_token={refresh_token}", GlobalSettings.Instance.ClientId, GlobalSettings.Instance.ClientSecret);
            GlobalSettings.Instance.AuthToken = userToken.AccessToken;
            return userToken.AccessToken;
        }

    }
}
