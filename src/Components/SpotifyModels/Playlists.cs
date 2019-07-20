using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tasprof.Components.SpotifyModels
{
    public class Playlists
    {
        [JsonProperty(PropertyName = "items")]
        public List<Playlist> Items { get; set; }
    }
}
