using Newtonsoft.Json;
using System.Collections.Generic;

namespace Tasprof.Apps.MySpotifyDroid.Models
{
    public class PlayHistoryItems
    {
        [JsonProperty(PropertyName = "items")]
        public List<PlayHistoryItem> Items { get; set; }

        [JsonProperty(PropertyName = "cursors")]
        public Cursors Cursors { get; set; }
    }
}
