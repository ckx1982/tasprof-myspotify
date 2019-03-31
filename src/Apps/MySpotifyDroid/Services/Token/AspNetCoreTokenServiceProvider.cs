using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Tasprof.Apps.MySpotifyDroid.Services.Token
{
    public class AspNetCoreTokenService: ITokenService
    {

        private IHttpContextAccessor _httpContextAccessor;
        public AspNetCoreTokenService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        Task<string> ITokenService.GetTokenAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
