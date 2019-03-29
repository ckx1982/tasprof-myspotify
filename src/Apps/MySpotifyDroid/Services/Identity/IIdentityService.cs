using System.Threading.Tasks;
using Tasprof.Apps.MySpotifyDroid.Models;

namespace Tasprof.Apps.MySpotifyDroid.Services.Identity
{
    public interface IIdentityService
    {
        string CreateAuthorizationRequest();
        string CreateLogoutRequest(string token);
        Task<UserToken> GetTokenAsync(string code);

    }
}
