using System;
using System.Collections.Generic;
using System.Text;

namespace Tasprof.Components.SpotifyChart.Services
{
    public interface ISpotifyChartExportService
    {
        void ExportChart(Models.SpotifyChart spotifyChart, string filename);
    }
}
