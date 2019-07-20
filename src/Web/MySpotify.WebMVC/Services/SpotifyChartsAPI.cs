
using System.Threading.Tasks;
using Tasprof.Components.MyUtilities.Services.HttpRequest;
using Tasprof.Components.SpotifyChart.Models;

namespace Tasprof.Apps.MySpotify.WebMvc.Services
{
    public class SpotifyChartsAPI : ISpotifyChartsAPI
    {
        private const string EndPointUrl = "https://localhost:5002/api/spotifycharts/";
        private readonly IHttpRequestService _httpRequestService;

        public SpotifyChartsAPI(IHttpRequestService httpRequestService)
        {
            _httpRequestService = httpRequestService;
        }

        public async Task<SpotifyChart> CreateSpotifyChart(string playlistId)
        {
            return await _httpRequestService.GetAsync<SpotifyChart>($"{EndPointUrl}{ playlistId}");
        }

        public async Task<SpotifyChart> SaveSpotifyChart(SpotifyChart spotifyChart)
        {
           return await _httpRequestService.PostAsync(EndPointUrl, spotifyChart);
        }
    }
}