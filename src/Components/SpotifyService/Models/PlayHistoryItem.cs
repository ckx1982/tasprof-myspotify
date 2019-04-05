using Newtonsoft.Json;
using System;

namespace Tasprof.Components.SpotifyClient.Models
{
    public class PlayHistoryItem
    {
        [JsonProperty(PropertyName = "track")]
        public Track Track { get; set; }

        [JsonProperty(PropertyName = "played_at")]
        public DateTime PlayedAt { get; set; }
    }
}