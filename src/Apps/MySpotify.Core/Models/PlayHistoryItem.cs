using Newtonsoft.Json;
using System;

namespace Tasprof.Apps.MySpotify.Core.Models
{
    public class PlayHistoryItem
    {
        [JsonProperty(PropertyName = "track")]
        public Track Track { get; set; }

        [JsonProperty(PropertyName = "played_at")]
        public DateTime PlayedAt { get; set; }

        public string PlayedAtFormatted => PlayedAt.ToString("dd/MM/yy HH24:mm");
    }
}