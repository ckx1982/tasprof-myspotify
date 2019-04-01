using System.Threading.Tasks;

namespace Tasprof.Apps.MySpotifyDroid.Services.Token
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

        public Task<string> GetNewAccessTokenAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
