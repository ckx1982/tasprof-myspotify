using Newtonsoft.Json;

namespace Tasprof.Apps.MySpotifyDroid.Models
{
    public class Cursors
    {
        [JsonProperty(PropertyName ="after")]
        public long After { get; set; }

        [JsonProperty(PropertyName = "before")]
        public long Before { get; set; }
    }
}
