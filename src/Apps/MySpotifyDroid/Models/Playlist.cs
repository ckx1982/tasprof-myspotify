﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Tasprof.Apps.MySpotifyDroid.Models
{
    public class Playlist
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "images")]
        public List<Image> Images { get; set; }

        public Image MainImage => Images.OrderByDescending(x=> x.Width).FirstOrDefault();
    }
}