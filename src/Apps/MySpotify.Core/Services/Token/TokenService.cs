using System.Threading.Tasks;
using Tasprof.Apps.MySpotify.Core.Constants;
using Tasprof.Apps.MySpotify.Core.Models;
using Tasprof.Apps.MySpotify.Core.Services.Request;

namespace Tasprof.Apps.MySpotify.Core.Services.Token
{
    public class TokenService: ITokenService
    {
        private readonly IGlobalSettingsService _globalSettingsService;

        public TokenService(IGlobalSettingsService globalSettingsService)
        {
            _globalSettingsService = globalSettingsService;
        }

        public async Task<string> GetAccessTokenAsync()
        {
            await Task.Delay(1);
            return _globalSettingsService.AccessToken;
        }

        public async Task<string> GetNewAccessTokenAsync(IRequestService requestService)
        {
            _globalSettingsService.AccessToken = string.Empty;
            var refresh_token = _globalSettingsService.RefreshToken;

            var userToken = await requestService.PostAsync<UserToken>(SpotifyWebApi.TokenUri, $"grant_type=refresh_token&refresh_token={refresh_token}",
                                                                      _globalSettingsService.ClientId, _globalSettingsService.ClientSecret);

            _globalSettingsService.AccessToken = userToken.AccessToken;
            return userToken.AccessToken;
        }
    }
}
