using Newtonsoft.Json;
using System.Collections.Generic;

namespace Tasprof.Components.SpotifyModels
{
    public class PlayHistoryItems
    {
        [JsonProperty(PropertyName = "items")]
        public List<PlayHistoryItem> Items { get; set; }

        [JsonProperty(PropertyName = "cursors")]
        public Cursors Cursors { get; set; }
    }
}
