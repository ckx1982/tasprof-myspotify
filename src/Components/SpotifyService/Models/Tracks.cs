using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tasprof.Components.SpotifyClient.Models
{
    public class Tracks
    {
        [JsonProperty(PropertyName ="items")]
        public List<Track> Items { get; set; }
    }
}
