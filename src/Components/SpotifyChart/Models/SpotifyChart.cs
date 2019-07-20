using System;
using System.Collections.Generic;

namespace Tasprof.Components.SpotifyChart.Models
{
    public class SpotifyChart
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string Title { get; set; }
        public IList<SpotifyChartItem> Items { get; set; }
    }
}
