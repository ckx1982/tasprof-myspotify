using System;
namespace Tasprof.Components.SpotifyChart.Models
{
    public class SpotifyChartItem
    {
        public virtual int Id { get; set; }

        public virtual string Artist { get; set; }

        public virtual string Title { get; set; }

        public virtual int Position { get; set; }

        public virtual DateTime Created { get; set; }
        
        public virtual DateTime Updated { get; set; } 

        public virtual SpotifyChart Chart { get; set; }
    }
}
