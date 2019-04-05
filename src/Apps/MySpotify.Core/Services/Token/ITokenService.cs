using System;
using System.Threading.Tasks;
using Tasprof.Apps.MySpotify.Core.Services.Request;

namespace Tasprof.Apps.MySpotify.Core.Services.Token
{
    public interface ITokenService
    {
        Task<string> GetAccessTokenAsync();
        Task<string> GetNewAccessTokenAsync(IRequestService requestService);
    }
}
