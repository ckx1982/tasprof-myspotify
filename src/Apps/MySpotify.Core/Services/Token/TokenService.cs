using System.Threading.Tasks;
using Tasprof.Apps.MySpotify.Core.Models;
using Tasprof.Apps.MySpotify.Core.Services.Request;

namespace Tasprof.Apps.MySpotify.Core.Services.Token
{
    public class TokenService: ITokenService
    {
        public TokenService()
        {
        }

        public async Task<string> GetAccessTokenAsync()
        {
            await Task.Delay(1);
            return GlobalSettings.Instance.AuthToken;
        }

        public async Task<string> GetNewAccessTokenAsync(IRequestService requestService)
        {
            GlobalSettings.Instance.AuthToken = string.Empty;
            var refresh_token = GlobalSettings.Instance.RefreshToken;
            var userToken = await requestService.PostAsync<UserToken>(GlobalSettings.Instance.TokenUri, $"grant_type=refresh_token&refresh_token={refresh_token}", GlobalSettings.Instance.ClientId, GlobalSettings.Instance.ClientSecret);
            GlobalSettings.Instance.AuthToken = userToken.AccessToken;
            return userToken.AccessToken;
        }
    }
}
