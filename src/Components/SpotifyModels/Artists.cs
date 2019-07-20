using Newtonsoft.Json;
using System.Collections.Generic;

namespace Tasprof.Components.SpotifyModels
{
    public class Artists
    {
        [JsonProperty(PropertyName ="items")]
        public List<Artist> Items { get; set; }
    }
}

