using Newtonsoft.Json;
using System.Collections.Generic;

namespace Tasprof.Components.SpotifyClient.Models
{
    public class Artists
    {
        [JsonProperty(PropertyName ="items")]
        public List<Artist> Items { get; set; }
    }
}

