using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Tasprof.Apps.MySpotify.Core.Models
{
    public class Playlist
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "images")]
        public List<Image> Images { get; set; }

        public Image MainImage => Images.DefaultIfEmpty(new Image()).OrderByDescending(x=> x.Width).FirstOrDefault();
    }
}
