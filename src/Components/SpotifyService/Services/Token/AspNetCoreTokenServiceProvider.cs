using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Tasprof.Components.MyUtilities.Services.HttpRequest;
using Tasprof.Components.MyUtilities.Services.Token;
using Tasprof.Components.SpotifyClient.Constants;
using Tasprof.Components.SpotifyClient.Models;

namespace Tasprof.Components.SpotifyClient.Services.Token
{
    public class AspNetCoreTokenServiceProvider : BaseService, ITokenService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AspNetCoreTokenServiceProvider(IHttpContextAccessor httpContextAccessor, IGlobalSettings globalSettings)
        {
            _httpContextAccessor = httpContextAccessor;
            GlobalSettings = globalSettings;
        }

        public async Task<string> GetAccessTokenAsync()
        {
            if (string.IsNullOrEmpty(GlobalSettings.AuthToken))
            {
                GlobalSettings.AuthToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");
            }
            return GlobalSettings.AuthToken;
        }

        public async Task<string> GetNewAccessTokenAsync(IHttpRequestService requestService)
        {
            GlobalSettings.AuthToken = string.Empty;
            var refresh_token = await _httpContextAccessor.HttpContext.GetTokenAsync("refresh_token");
            var userToken = await requestService.PostAsync<UserToken>(SpotifyWebApi.TokenUri, $"grant_type=refresh_token&refresh_token={refresh_token}", GlobalSettings.ClientId, GlobalSettings.ClientSecret);
            GlobalSettings.AuthToken = userToken.AccessToken;
            return userToken.AccessToken;
        }

    }
}
