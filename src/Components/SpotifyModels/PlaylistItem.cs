
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Tasprof.Components.SpotifyModels
{
    public class PlaylistItem
    {
        [JsonProperty(PropertyName = "track")]
        public Track Track { get; set; }
    }
}
