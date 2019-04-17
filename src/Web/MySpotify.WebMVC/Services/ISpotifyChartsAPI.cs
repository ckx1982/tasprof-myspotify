using System.Threading.Tasks;
using Tasprof.Components.SpotifyChart.Models;

namespace Tasprof.Apps.MySpotify.WebMvc.Services
{
    public interface ISpotifyChartsAPI
    {
        Task<SpotifyChart> CreateSpotifyChart(string playlistId);
        Task<SpotifyChart> SaveSpotifyChart(SpotifyChart spotifyChart);
    }
}