using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Tasprof.Apps.MySpotify.Core.Constants;
using Tasprof.Apps.MySpotify.Core.Models;
using Tasprof.Apps.MySpotify.Core.Services.Request;

namespace Tasprof.Apps.MySpotify.Core.Services.Token
{
    public class AspNetCoreTokenServiceProvider : ITokenService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IGlobalSettingsService _globalSettingsService;

        public AspNetCoreTokenServiceProvider(IHttpContextAccessor httpContextAccessor, IGlobalSettingsService globalSettingsService)
        {
            _httpContextAccessor = httpContextAccessor;
            _globalSettingsService = globalSettingsService;
        }

        public async Task<string> GetAccessTokenAsync()
        {
            if (string.IsNullOrEmpty(_globalSettingsService.AccessToken))
            {
                _globalSettingsService.AccessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");
            }
            return _globalSettingsService.AccessToken;
        }

        public async Task<string> GetNewAccessTokenAsync(IRequestService requestService)
        {
            _globalSettingsService.AccessToken = string.Empty;
            var refresh_token = await _httpContextAccessor.HttpContext.GetTokenAsync("refresh_token");

            var userToken = await requestService.PostAsync<UserToken>(SpotifyWebApi.TokenUri, $"grant_type=refresh_token&refresh_token={refresh_token}", 
                                                                      _globalSettingsService.ClientId, _globalSettingsService.ClientSecret);

            _globalSettingsService.AccessToken = userToken.AccessToken;
            return userToken.AccessToken;
        }

    }
}
