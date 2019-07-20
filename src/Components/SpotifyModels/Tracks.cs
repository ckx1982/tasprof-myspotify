using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tasprof.Components.SpotifyModels
{
    public class Tracks
    {
        [JsonProperty(PropertyName ="items")]
        public List<Track> Items { get; set; }
    }
}
