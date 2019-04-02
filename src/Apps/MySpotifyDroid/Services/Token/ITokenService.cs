using System;
using System.Threading.Tasks;
using Tasprof.Apps.MySpotifyDroid.Services.Request;

namespace Tasprof.Apps.MySpotifyDroid.Services.Token
{
    public interface ITokenService
    {
        Task<string> GetAccessTokenAsync();
        Task<string> GetNewAccessTokenAsync(IRequestService requestService);
    }
}
