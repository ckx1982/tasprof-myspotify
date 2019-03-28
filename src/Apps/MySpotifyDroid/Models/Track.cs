
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Tasprof.Apps.MySpotifyDroid.Models
{
    public class Track
    {
        [JsonProperty(PropertyName = "artists")]
        public List<Artist> Artists { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "album")]
        public Album Album { get; set; }

        public Artist MainArtist => Artists.First();
    }
}
