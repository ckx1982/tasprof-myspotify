using System;
using System.Collections.Generic;
using System.Text;

namespace Tasprof.Components.SpotifyChart.Models
{
    public class SpotifyChartTrack
    {
        public virtual int Id { get; set; }

        public virtual string Artist { get; set; }

        public virtual string Title { get; set; }

        public virtual ICollection<SpotifyChartItem> ChartItems { get; set; }
        
        public virtual DateTime Created { get; set; }

        public virtual DateTime Updated { get; set; }
    }
}
