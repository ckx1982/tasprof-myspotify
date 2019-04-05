using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tasprof.Components.SpotifyClient.Models
{
    public class PlaylistItems
    {
        [JsonProperty(PropertyName ="items")]
        public List<PlaylistItem> Items { get; set; }
    }
}
