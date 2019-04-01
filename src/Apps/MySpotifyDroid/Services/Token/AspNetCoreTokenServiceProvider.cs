using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Tasprof.Apps.MySpotifyDroid.Services.Request;

namespace Tasprof.Apps.MySpotifyDroid.Services.Token
{
    public class AspNetCoreTokenService : ITokenService
    {
        private readonly IRequestService _requestService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AspNetCoreTokenService(IRequestService requestService, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _requestService = requestService;
        }

        public async Task<string> GetAccessTokenAsync()
        {
            if (string.IsNullOrEmpty(GlobalSettings.Instance.AuthToken))
            {
                GlobalSettings.Instance.AuthToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");
            }
            return GlobalSettings.Instance.AuthToken;
        }

        public async Task<string> GetNewAccessTokenAsync()
        {
            var refresh_token = await _httpContextAccessor.HttpContext.GetTokenAsync("refresh_token");
            var access_token = await _requestService.PostAsync(GlobalSettings.Instance.TokenUri, $"{{ 'grant_type': 'refresh_token', 'refresh_token': '{refresh_token}'}}");
            GlobalSettings.Instance.AuthToken = access_token;
            return access_token;
        }

    }
}
