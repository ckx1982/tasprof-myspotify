using System;
using System.Collections.Generic;

namespace Tasprof.Components.SpotifyChart.Models
{
    public class SpotifyChart
    {
        public SpotifyChart()
        {
            ChartItems = new List<SpotifyChartItem>();
        }
        public virtual int Id { get; set; }

        public virtual DateTime ValidFrom { get; set; }

        public virtual DateTime ValidUntil { get; set; }

        public virtual DateTime Created { get; set; } = DateTime.Today;

        public virtual DateTime Updated { get; set; } = DateTime.Today;

        public virtual IList<SpotifyChartItem> ChartItems { get; set; }

        public virtual void AddChartTrack(SpotifyChartTrack chartTrack)
        {
            var chartItem = new SpotifyChartItem
            {
                Chart = this,
                ChartTrack = chartTrack,
                Position = ChartItems.Count + 1,
                Created = DateTime.Now,
                Updated = DateTime.Now
            };

            ChartItems.Add(chartItem);
            chartTrack.ChartItems.Add(chartItem);
        }

    }
}
