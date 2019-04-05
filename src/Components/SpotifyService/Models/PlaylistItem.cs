
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Tasprof.Components.SpotifyClient.Models
{
    public class PlaylistItem
    {
        [JsonProperty(PropertyName = "track")]
        public Track Track { get; set; }
    }
}
