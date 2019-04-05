using System;
using System.Threading.Tasks;
using Tasprof.Components.SpotifyClient.Services.Request;

namespace Tasprof.Components.SpotifyClient.Services.Token
{
    public interface ITokenService
    {
        Task<string> GetAccessTokenAsync();
        Task<string> GetNewAccessTokenAsync(IRequestService requestService);
    }
}
