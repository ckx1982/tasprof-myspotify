using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Tasprof.Components.SpotifyClient.Constants;
using Tasprof.Components.SpotifyClient.Models;
using Tasprof.Components.SpotifyClient.Services.Request;

namespace Tasprof.Components.SpotifyClient.Services.Token
{
    public class AspNetCoreTokenServiceProvider : BaseService<IGlobalSettings>, ITokenService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AspNetCoreTokenServiceProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> GetAccessTokenAsync()
        {
            if (string.IsNullOrEmpty(GlobalSettings.AuthToken))
            {
                GlobalSettings.AuthToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");
            }
            return GlobalSettings.AuthToken;
        }

        public async Task<string> GetNewAccessTokenAsync(IRequestService requestService)
        {
            GlobalSettings.AuthToken = string.Empty;
            var refresh_token = await _httpContextAccessor.HttpContext.GetTokenAsync("refresh_token");
            var userToken = await requestService.PostAsync<UserToken>(SpotifyWebApi.TokenUri, $"grant_type=refresh_token&refresh_token={refresh_token}", GlobalSettings.ClientId, GlobalSettings.ClientSecret);
            GlobalSettings.AuthToken = userToken.AccessToken;
            return userToken.AccessToken;
        }

    }
}
