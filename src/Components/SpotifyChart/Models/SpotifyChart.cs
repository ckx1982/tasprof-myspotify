using System;
using System.Collections.Generic;

namespace Tasprof.Components.SpotifyChart.Models
{
    public class SpotifyChart
    {
        public virtual int Id { get; set; }

        public virtual DateTime ValidFrom { get; set; }

        public virtual DateTime ValidUntil { get; set; }

        public virtual DateTime Created { get; set; } = DateTime.Today;

        public virtual DateTime Updated { get; set; } = DateTime.Today;

        public virtual ICollection<SpotifyChartItem> Items { get; set; }

    }
}
