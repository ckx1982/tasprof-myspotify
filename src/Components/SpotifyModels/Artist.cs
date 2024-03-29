﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Tasprof.Components.SpotifyModels
{
    public class Artist
    {
        [JsonProperty(PropertyName ="name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName ="images")]
        public List<Image> Images { get; set; }

        public Image MainImage => Images.First();

    }
}
