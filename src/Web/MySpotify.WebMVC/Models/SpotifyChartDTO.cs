using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasprof.Apps.MySpotify.WebMvc.Models
{
    public class SpotifyChartDTO
    {
        public string Title { get; set; }
        public IEnumerable<SpotifyChartItemDTO> Items { get; set; }
    }
}
