﻿using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Tasprof.Components.SpotifyModels
{
    public class Album
    {
        [JsonProperty(PropertyName = "images")]
        public List<Image> Images { get; set; }

        public Image MainImage => Images.First();
    }
}
