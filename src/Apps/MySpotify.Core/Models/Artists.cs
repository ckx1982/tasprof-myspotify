using Newtonsoft.Json;
using System.Collections.Generic;

namespace Tasprof.Apps.MySpotify.Core.Models
{
    public class Artists
    {
        [JsonProperty(PropertyName ="items")]
        public List<Artist> Items { get; set; }
    }
}

