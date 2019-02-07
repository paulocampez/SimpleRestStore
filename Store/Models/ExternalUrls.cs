using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class ExternalUrls
    {
        [JsonProperty(PropertyName = "spotify")]
        public string Spotify { get; set; }
    }
}