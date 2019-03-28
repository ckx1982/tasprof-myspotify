using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tasprof.Apps.MySpotifyDroid.Models
{
    public class Playlists
    {
        [JsonProperty(PropertyName = "items")]
        public List<Playlist> Items { get; set; }
    }
}
