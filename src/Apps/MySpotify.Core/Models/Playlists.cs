using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tasprof.Apps.MySpotify.Core.Models
{
    public class Playlists
    {
        [JsonProperty(PropertyName = "items")]
        public List<Playlist> Items { get; set; }
    }
}
