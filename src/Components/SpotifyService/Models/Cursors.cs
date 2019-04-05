using Newtonsoft.Json;

namespace Tasprof.Components.SpotifyClient.Models
{
    public class Cursors
    {
        [JsonProperty(PropertyName ="after")]
        public long After { get; set; }

        [JsonProperty(PropertyName = "before")]
        public long Before { get; set; }
    }
}
