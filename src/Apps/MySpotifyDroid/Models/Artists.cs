using Newtonsoft.Json;
using System.Collections.Generic;

namespace Tasprof.Apps.MySpotifyDroid.Models
{
    public class Artists
    {
        [JsonProperty(PropertyName ="items")]
        public List<Artist> Items { get; set; }
    }
}

