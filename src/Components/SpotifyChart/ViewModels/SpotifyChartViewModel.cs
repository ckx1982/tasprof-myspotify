using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Tasprof.Components.SpotifyChart.ViewModels
{
    [DataContract(Name="chart")]
    public class SpotifyChartViewModel
    {
        [DataMember(Name="items")]
        public IEnumerable<SpotifyChartItemViewModel> Items { get; set; }
    }
}
