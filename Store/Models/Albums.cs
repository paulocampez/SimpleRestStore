using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class Albums
    {
        [JsonProperty("albums")]
        public List<Album> AlbumsList { get; set; }
    }
}