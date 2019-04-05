
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Tasprof.Apps.MySpotify.Core.Models
{
    public class PlaylistItem
    {
        [JsonProperty(PropertyName = "track")]
        public Track Track { get; set; }
    }
}
