using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Tasprof.Apps.MySpotifyDroid.Models
{
    public class Album
    {
        [JsonProperty(PropertyName = "images")]
        public List<Image> Images { get; set; }

        public Image MainImage => Images.First();
    }
}
