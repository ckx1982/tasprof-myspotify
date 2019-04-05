using System.Threading.Tasks;
using Tasprof.Apps.MySpotify.Core.Models;

namespace Tasprof.Apps.MySpotify.Core.Services.Identity
{
    public interface IIdentityService
    {
        string CreateAuthorizationRequest();
        string CreateLogoutRequest(string token);
        Task<UserToken> GetTokenAsync(string code);

    }
}
