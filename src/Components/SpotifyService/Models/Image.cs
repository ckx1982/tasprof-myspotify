using Newtonsoft.Json;
using FFImageLoading.Transformations;
using System.Collections.Generic;
using FFImageLoading.Work;

namespace Tasprof.Components.SpotifyClient.Models
{
    public class Image
    {
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "width")]
        public int Width { get; set; }

        [JsonProperty(PropertyName = "height")]
        public int Height { get; set; }

        public double DownsampleWidth => 200d;
        public List<ITransformation> Transformations => new List<ITransformation> { new CircleTransformation() };


    }
}