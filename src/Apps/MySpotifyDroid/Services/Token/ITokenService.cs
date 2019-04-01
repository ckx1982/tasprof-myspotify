using System;
using System.Threading.Tasks;

namespace Tasprof.Apps.MySpotifyDroid.Services.Token
{
    public interface ITokenService
    {
        Task<string> GetAccessTokenAsync();
        Task<string> GetNewAccessTokenAsync();
    }
}
