using System.Threading.Tasks;
using Tasprof.Components.MyUtilities.Services.HttpRequest;
using Tasprof.Components.MyUtilities.Services.Token;
using Tasprof.Components.SpotifyClient.Constants;
using Tasprof.Components.SpotifyModels;

namespace Tasprof.Components.SpotifyClient.Services.Token
{
    public class TokenService: BaseService, ITokenService
    {
      
        public TokenService(IGlobalSettings globalSettings)
        {
            GlobalSettings = globalSettings;
        }

        public async Task<string> GetAccessTokenAsync()
        {
            await Task.Delay(1);
            return GlobalSettings.AuthToken;
        }

        public async Task<string> GetNewAccessTokenAsync(IHttpRequestService requestService)
        {
            GlobalSettings.AuthToken = string.Empty;
            var refresh_token = GlobalSettings.RefreshToken;
            var userToken = await requestService.PostAsync<UserToken>(SpotifyWebApi.TokenUri, $"grant_type=refresh_token&refresh_token={refresh_token}", GlobalSettings.ClientId, GlobalSettings.ClientSecret);
            GlobalSettings.AuthToken = userToken.AccessToken;
            return userToken.AccessToken;
        }
    }
}
