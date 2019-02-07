using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class Items
    {
        [JsonProperty("items")]
        public List<Item> AlbumsList { get; set; }
    }
}