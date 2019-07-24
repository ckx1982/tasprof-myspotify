using System;
using System.Collections.Generic;

namespace Tasprof.Components.SpotifyChart.Models
{
    public class SpotifyChart
    {
        public virtual int Id { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual string Title { get; set; }
        public virtual ICollection<SpotifyChartItem> Items { get; set; }
    }
}
