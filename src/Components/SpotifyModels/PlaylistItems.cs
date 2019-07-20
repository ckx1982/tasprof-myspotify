using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tasprof.Components.SpotifyModels
{
    public class PlaylistItems
    {
        [JsonProperty(PropertyName ="items")]
        public List<PlaylistItem> Items { get; set; }
    }
}
