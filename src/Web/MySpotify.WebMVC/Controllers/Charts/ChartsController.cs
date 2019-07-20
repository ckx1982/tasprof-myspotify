using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using Tasprof.Components.SpotifyChart.Services;
using Tasprof.Components.SpotifyClient;

namespace Tasprof.Apps.MySpotify.WebMvc.Controllers.Charts
{
    public class ChartsController : Controller
    {
        private readonly ISpotifyClient _spotifyClient;
        private readonly ISpotifyChartExportService _spotifyChartExportService;
        private readonly ISpotifyChartHelperService _spotifyChartHelperService;

        public ChartsController(ISpotifyClient spotifyClient, 
                                ISpotifyChartExportService spotifyChartExportService,
                                ISpotifyChartHelperService spotifyChartHelperService)
        {
            _spotifyClient = spotifyClient;
            _spotifyChartExportService = spotifyChartExportService;
            _spotifyChartHelperService = spotifyChartHelperService;
        }

        [Authorize]
        public async Task<IActionResult> Export(string id)
        {
            var playlistItems = await _spotifyClient.SpotifyService.GetPlaylistItems(id);
            var spotifyChart = _spotifyChartHelperService.ConvertSpotifyPlaylistItemsToSpotifyChart(playlistItems);
            var fileName = $@"C:\temp\export_{DateTime.Now.Ticks}.xlsx";
            _spotifyChartExportService.ExportChart(spotifyChart, fileName);

            var memory = new MemoryStream();
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "export.xlsx");
        }
    }
}
