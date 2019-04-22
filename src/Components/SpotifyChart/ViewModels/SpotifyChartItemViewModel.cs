using System.Runtime.Serialization;

namespace Tasprof.Components.SpotifyChart.ViewModels
{
    [DataContract(Name ="item")]
    public class SpotifyChartItemViewModel
    {
        public string Artist { get; set; }
        public string Title { get; set; }
    }
}