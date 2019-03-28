using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tasprof.Apps.MySpotifyDroid.Models
{
    public class Tracks
    {
        [JsonProperty(PropertyName ="items")]
        public List<Track> Items { get; set; }
    }
}
