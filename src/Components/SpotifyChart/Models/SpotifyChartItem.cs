using System;
namespace Tasprof.Components.SpotifyChart.Models
{
    public class SpotifyChartItem
    {
        public int Id { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public int Position { get; set; }
        public DateTime Created { get; set; } 
        public DateTime Updated { get; set; } 

        public SpotifyChart Chart { get; set; }
    }
}
