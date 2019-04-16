using System;
using System.Threading.Tasks;
using Tasprof.Components.SpotifyChart.Models;

namespace Tasprof.Components.SpotifyClient.Services.SpotifyChart
{
    public interface ISpotifyChartService
    {
        Task<Components.SpotifyChart.Models.SpotifyChart> CreateChart(string playlistId);
    }
}
