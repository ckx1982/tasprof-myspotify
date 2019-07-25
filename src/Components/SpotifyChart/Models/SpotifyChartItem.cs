using System;
namespace Tasprof.Components.SpotifyChart.Models
{
    public class SpotifyChartItem
    {
        public virtual int Id { get; set; }

        public virtual int Position { get; set; }

        public virtual DateTime Created { get; set; } = DateTime.Now;

        public virtual DateTime Updated { get; set; } = DateTime.Now;

        public virtual SpotifyChartTrack ChartTrack { get; set; }

        public virtual SpotifyChart Chart { get; set; }
    }
}
